using System.Text.Json.Serialization;
using TaskManagement.Shared;

namespace TaskManagement.Service.Models;

public class ProductItem : IVM
{
    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>
    /// The product identifier.
    /// </value>
    int ProductId { get; set; }
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    /// <value>
    /// The name of the product.
    /// </value>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the product description.
    /// </summary>
    /// <value>
    /// The product description.
    /// </value>
    public string ProductDescription { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the product price.
    /// </summary>
    /// <value>
    /// The product price.
    /// </value>
    public double ProductPrice { get; set; }
    /// <summary>
    /// Gets or sets the sku.
    /// </summary>
    /// <value>
    /// The sku.
    /// </value>
    public string SKU { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>
    /// The product.
    /// </value>
    [JsonIgnore]
    public Product Product { get; set; }
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
}