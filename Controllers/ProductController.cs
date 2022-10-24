using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using RAS.Bootcamp.MVC.NET.Models.Request;
using RAS.Bootcamp.MVC.NET.Models.Entity;
using RAS.Bootcamp.MVC.NET.Models;
using Microsoft.AspNetCore.Authorization;

namespace RAS.Bootcamp.MVC.NET.Controllers;
[Authorize]
public class ProductController : Controller
{
    private readonly dbcontext _dbContext;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, dbcontext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
        
    }
    [Authorize(Roles = "Penjual")]
    [HttpGet]
    public IActionResult Index()
    {
        var dataiduser= int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
        var penjual = _dbContext.Penjuals.First(x=> x.IdUser == dataiduser);
        List<Barang> barangs = _dbContext.Barangs.Where(e=> e.IdPenjual== penjual.Id).ToList();
        return View(barangs);
    }
    
    //buat delete data

    [HttpGet]
    public IActionResult Deletedata(int id)
    {
        Barang deleted = _dbContext.Barangs.First(x => x.Id == id);
        var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images");
        var filepath = Path.Combine(folder,deleted.imgname);
        System.IO.File.Delete(filepath);

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
        var filename = $"{br.Kode}-{br.imgname.FileName}";
        var filepath = Path.Combine(folder,filename);
        using var stream = System.IO.File.Create(filepath);
        if (br.imgname != null){
            br.imgname.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";
        
        var dataiduser= int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
        var penjual = _dbContext.Penjuals.First(x=> x.IdUser == dataiduser);
        
        Barang input = new Barang {
            Kode = br.Kode,
            Nama = br.Nama,
            Harga = br.Harga,
            Description = br.Description,
            Stok = br.Stok,
            imgname = filename,
            url = url,
            IdPenjual = penjual.Id
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

        RequestBarang data = new RequestBarang{
            Nama = br.Nama,
            Id = br.Id,
            Description = br.Description,
            Harga = br.Harga,
            Stok = br.Stok,
            Kode = br.Kode
        };
        return View(data);
    }
    
    [HttpPost]
    public IActionResult Editdata(RequestBarang br)
    {   
        
        //Ngurus Input data baru
        var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images");
        var filename = $"{br.Kode}-{br.imgname.FileName}";
        var filepath = Path.Combine(folder,filename);
        using var stream = System.IO.File.Create(filepath);
        if (br.imgname != null){
            br.imgname.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";    
        
        // Perubahan Data ke database
        Barang updated = _dbContext.Barangs.First(x => x.Id == br.Id);
        var Deletedfilepath = Path.Combine(folder,updated.imgname);
        System.IO.File.Delete(Deletedfilepath);

        updated.Kode = br.Kode;
        updated.Harga = br.Harga;
        updated.Nama = br.Nama;
        updated.Stok = br.Stok;
        updated.Description = br.Description;
        updated.url = url;
        updated.imgname = filename;
        _dbContext.SaveChanges();
        return RedirectToAction("Index");  
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
