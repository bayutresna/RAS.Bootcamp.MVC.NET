using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.MVC.NET.Models.Entity;

namespace RAS.Bootcamp.MVC.NET.Models;
public class dbcontext: DbContext {
    public dbcontext(DbContextOptions<dbcontext> options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Penjual> Penjuals { get; set; }
    public DbSet<Barang> Barangs { get; set; }
    public DbSet<Pembeli> Pembelis {get;set;}
}