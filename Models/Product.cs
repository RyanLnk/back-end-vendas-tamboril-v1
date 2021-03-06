using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class Product
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(45)")]
  public string Name { get; set; }

  [Required]
  [Column(TypeName = "decimal(10,2)")]
  public decimal SalePrice { get; set; }

  [Column(TypeName = "varchar(45)")]
  public string Description { get; set; }

  [Required]
  [Column(TypeName = "decimal(65,2)")]
  public decimal Quantity { get; set; }

  public Category Category { get; set; }
  public int CategoryId { get; set; }

  public List<SalesHasProduct> Products { get; set; }
}
