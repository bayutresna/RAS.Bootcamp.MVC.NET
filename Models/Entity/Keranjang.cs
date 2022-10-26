using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RAS.Bootcamp.MVC.NET.Models.Entity;
[Index(nameof(IdBarang),nameof(IdUser), IsUnique = true)]
public class Keranjang {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    
    [ForeignKey("Barang")]
    
    public int IdBarang { get; set; }
    public decimal HargaSatuan { get; set; }
    [ForeignKey("User")]
    public int IdUser { get; set; }
    public int Jumlah { get; set; }

    public virtual User User { get; set; }
    public virtual Barang Barang {get; set; }
}