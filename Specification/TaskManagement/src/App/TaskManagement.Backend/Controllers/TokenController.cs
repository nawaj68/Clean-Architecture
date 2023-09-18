using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.User.Command;
using TaskManagement.Models;

namespace TaskManagement.Backend.Controllers;

public class TokenController : ApiControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;

    public TokenController(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("")]
    public async Task<IActionResult> Login([FromServices] IConfiguration configuration,
        [FromBody] LoginModel.InputModel model)
    {
        return await HandleCommandAsync(new UserLoginCommand(model.Email, model.Password));
    }
}