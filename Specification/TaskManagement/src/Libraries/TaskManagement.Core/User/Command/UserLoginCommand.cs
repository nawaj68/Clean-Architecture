using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;
using ValidationException = TaskManagement.Shared.Common.Exceptions.ValidationException;

namespace TaskManagement.Core.User.Command;

public class UserLoginCommand : IRequest<CommandResult<TokenResponse>>
{
    public UserLoginCommand(string email,string password)
    {
        Email = email;
        Password= password;
    }
    public string Email { get; set; }

    public string Password { get; set; }

    [UsedImplicitly]
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, CommandResult<TokenResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IValidator<UserLoginCommand> _validator;

        public UserLoginCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IValidator<UserLoginCommand> validator)
        {
            _userManager = userManager;
            _configuration = configuration;
            _validator = validator;
        }

        /// <inheritdoc />
        public async Task<CommandResult<TokenResponse>> Handle(UserLoginCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return new CommandResult<TokenResponse>(null, CommandResultTypeEnum.UnAuthorized);

            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Name, user.UserName!),
                new(JwtRegisteredClaimNames.Email, user.Email !),
                new Claim("UserId", user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var secretKey = jwtConfig["secret"];
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey!));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            await _userManager.SetAuthenticationTokenAsync(user, "TASKManager", "authToken", tokenString);
            return new CommandResult<TokenResponse>(new TokenResponse(tokenString, token.ValidTo),
                CommandResultTypeEnum.Success);
        }
    }
}