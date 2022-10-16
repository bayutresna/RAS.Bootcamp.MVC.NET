using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RAS.Bootcamp.MVC.NET.Models.Entity;

public class Pembeli {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    [ForeignKey("User")]
    public int IdUser { get; set; }
    public string? NamaPembeli {get;set;}
    public string? AlamatPembeli { get; set; }
    public virtual User User { get; set;}

}