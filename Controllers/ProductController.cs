using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.MVC.NET.Models;
using RAS.Bootcamp.MVC.NET.Models.Entity;

namespace RAS.Bootcamp.MVC.NET.Controllers;

public class ProductController : Controller
{
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
    public IActionResult Inputdata(RequestBarang br)
    {   
        var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images");
        if (!Directory.Exists(folder)){
            Directory.CreateDirectory(folder);
        }
        var filename = $"{br.Kode}-{br.imgname.FileName}";
        var filepath = Path.Combine(folder,filename);
        using var stream = System.IO.File.Create(filepath);
        if (br.imgname != null){
            br.imgname.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";
        
        Barang input = new Barang {
            Kode = br.Kode,
            Nama = br.Nama,
            Harga = br.Harga,
            Description = br.Description,
            Stok = br.Stok,
            imgname = filename,
            url = url,
            IdPenjual = 5
        };
        _dbContext.Barangs.Add(input);
        _dbContext.SaveChanges();
        List<Barang> data = _dbContext.Barangs.ToList();
        return View("Index",data);
        
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
