using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.MVC.NET.Models;
using RAS.Bootcamp.MVC.NET.Models.Entity;

namespace RAS.Bootcamp.MVC.NET.Controllers;

public class ProductController : Controller
{

//    static List<ProductInput> produk = new List<ProductInput>(){
//         new ProductInput {code = "01", nama = "laptop keren", harga = "5000", deskripsi = "laptop keren bisa gaming" }
//     };


    private readonly dbcontext _dbContext;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, dbcontext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
        
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<Barang> barangs = _dbContext.Barangs.ToList();
        return View(barangs);
    }
    
    //buat delete data
    [HttpGet]
    public IActionResult Deletedata(Barang br)
    {
        
        Barang deleted = _dbContext.Barangs.First(x => x.Id == br.Id);
        _dbContext.Barangs.Remove(deleted);
        _dbContext.SaveChanges();
         List<Barang> barangs = _dbContext.Barangs.ToList();
        return View("Index",barangs);
    }

    //input data
    [HttpGet]
    public IActionResult Inputdata()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inputdata(Barang br)
    {   
        try
            {
                // produk.Add(pr);
                br.IdPenjual = 4;
                _dbContext.Barangs.Add(br);
                _dbContext.SaveChanges();
                List<Barang> barangs = _dbContext.Barangs.ToList();
                return View("Index",barangs);
                // return View("Index");
            }
        catch
            {
                return View();
            }
        
    }

    //buat edit data
    [HttpGet]
    public IActionResult Editdata(int id)
    {
        Barang br = _dbContext.Barangs.First(x=> x.Id == id);
        return View(br);
    }

    [HttpPost]
    public IActionResult Editdata(Barang br)
    {   
        try
            {
                Barang updated = _dbContext.Barangs.First(x => x.Id == br.Id);
                updated.Kode = br.Kode;
                updated.Harga = br.Harga;
                updated.Nama = br.Nama;
                updated.Stok = br.Stok;
                updated.Description = br.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        catch
            {
                return View();
            }
        
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
