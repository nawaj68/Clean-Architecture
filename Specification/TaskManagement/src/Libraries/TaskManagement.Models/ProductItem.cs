using TaskManagement.Shared;
using TaskManagement.Shared.Common;

namespace TaskManagement.Models;

public class ProductItem : BaseAuditableEntity, IEntity
{
   
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
    public string SKU { get; set; } = string.Empty;

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
