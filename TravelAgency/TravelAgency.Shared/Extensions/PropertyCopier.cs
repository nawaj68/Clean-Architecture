using TravelAgency.Shared.Common;

namespace TravelAgency.Shared.Extensions;

public static class PropertyCopier
{
    private static string[] IgnoredProperties = new[] { "DomainEvents",nameof(BaseAuditableEntity.Created),
        nameof(BaseAuditableEntity.CreatedBy), nameof(BaseAuditableEntity.LastModified),nameof(BaseAuditableEntity.LastModifiedBy) ,nameof(BaseAuditableEntity.Status)  };

    public static void Copy<TParent, TChild>(this TParent parent, TChild child)
    where TParent : class
    where TChild : class
    {
        var parentProperties = parent.GetType().GetProperties();
        var childProperties = child.GetType().GetProperties();

        foreach (var parentProperty in parentProperties)
        {
            foreach (var childProperty in childProperties)
            {
                if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType && childProperty.CanWrite)
                {
                    if (IgnoredProperties.Contains(childProperty.Name))
                        break;
                    childProperty.SetValue(child, parentProperty.GetValue(parent));
                    break;
                }
            }
        }
    }
}
