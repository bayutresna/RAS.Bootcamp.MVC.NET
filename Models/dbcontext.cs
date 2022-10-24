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
    public DbSet<Transaksi> Transaksis{get;set;}
    public DbSet<ItemTransaksi> ItemTransaksis{get;set;}
    public DbSet<Keranjang> Keranjangs{get;set;}
}