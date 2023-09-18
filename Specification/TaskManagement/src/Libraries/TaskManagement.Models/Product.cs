using TaskManagement.Shared;
using TaskManagement.Shared.Common;

namespace TaskManagement.Models;

public class Product : BaseAuditableEntity, IEntity
{
    /// <summary>
    /// Product Name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Product Description
    /// </summary>
    public string ProductDescription { get; set; } = string.Empty;
    /// <summary>
    /// Product Price
    /// </summary>
    public double ProductPrice { get; set; }
    /// <summary>
    /// Product Color
    /// </summary>
    public string ProductColor { get; set; } = string.Empty;

    /// <summary>Gets or sets the product items.</summary>
    /// <value>The product items.</value>
    public ICollection<ProductItem> ProductItems { get; set;}=new HashSet<ProductItem>();
}
