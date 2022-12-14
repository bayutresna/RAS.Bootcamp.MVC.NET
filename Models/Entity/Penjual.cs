using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RAS.Bootcamp.MVC.NET.Models.Entity;

public class Penjual {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    [ForeignKey("User")]
    public int IdUser { get; set; }
    public string? NamaToko {get;set;}
    public string? AlamatToko { get; set; }
    public string? NoHP{get;set;}

    public virtual User User { get; set;}
    public virtual ICollection<Barang> Barangs { get; set; }
}