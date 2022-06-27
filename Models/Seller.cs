using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasTamboril.Models;

public class Seller
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Column(TypeName = "varchar(255)")]
  public string Name { get; set; }

  public DateTime CreationDate { get; set; }

  public DateTime UpdateDate { get; set; }

  public List<Sales> Sales { get; set; }
}
