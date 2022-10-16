using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.MVC.NET.Models;
using RAS.Bootcamp.MVC.NET.Models.Entity;

namespace RAS.Bootcamp.MVC.NET.Controllers;

public class UserController : Controller
{
    private readonly dbcontext _dbContext;

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, dbcontext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
        
    }
    [HttpGet]
    public IActionResult IndexPenjual()
    {
        List<Penjual> penjuals = _dbContext.Penjuals.ToList();
        return View(penjuals);
    }
    
    //buat delete data Penjual
    [HttpGet]
    public IActionResult DeletePenjual(Penjual pj)
    {
        
        Penjual deleted = _dbContext.Penjuals.First(x => x.Id == pj.Id);
        _dbContext.Penjuals.Remove(deleted);
        _dbContext.SaveChanges();
         List<Penjual> penjuals = _dbContext.Penjuals.ToList();
        return View("IndexPenjual",penjuals);
    }

    //input Data Penjual
    [HttpGet]
    public IActionResult InputPenjual()
    {
        return View();
    }

    [HttpPost]
    public IActionResult InputPenjual(Penjual pj)
    {   
        try
            {
                // produk.Add(pr);
                pj.IdUser = 1;
                _dbContext.Penjuals.Add(pj);
                _dbContext.SaveChanges();
                List<Penjual> penjuals = _dbContext.Penjuals.ToList();
                return View("IndexPenjual",penjuals);
                // return View("Index");
            }
        catch
            {
                return View("IndexPenjual");
            }
        
    }

    //buat edit 
    [HttpGet]
    public IActionResult EditPenjual(int id)
    {
        Penjual pj = _dbContext.Penjuals.First(x=> x.Id == id);
        return View(pj);
    }

    [HttpPost]
    public IActionResult EditPenjual(Penjual pj)
    {   
        try
            {
                Penjual updated = _dbContext.Penjuals.First(x => x.Id == pj.Id);
                updated.NamaToko = pj.NamaToko;
                updated.Alamat = pj.Alamat;
                _dbContext.SaveChanges();
                return RedirectToAction("IndexPenjual");
            }
        catch
            {
                return View();
            }
        
    }
    // BUAT PEMBELI YGY

    public IActionResult IndexPembeli()
    {
        List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
        return View(pembelis);
    }
    
    //buat delete 
    [HttpGet]
    public IActionResult DeletePembeli(Pembeli pb)
    {
        
        Pembeli deleted = _dbContext.Pembelis.First(x => x.Id == pb.Id);
        _dbContext.Pembelis.Remove(deleted);
        _dbContext.SaveChanges();
         List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
        return View("IndexPembeli",pembelis);
    }

    //input 
    [HttpGet]
    public IActionResult InputPembeli()
    {
        return View();
    }

    [HttpPost]
    public IActionResult InputPembeli(Pembeli pb)
    {   
        try
            {
                // produk.Add(pr);
                pb.IdUser = 1;
                _dbContext.Pembelis.Add(pb);
                _dbContext.SaveChanges();
                List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
                return View("IndexPembeli",pembelis);
                // return View("Index");
            }
        catch
            {
                return View("IndexPembeli");
            }
        
    }

    //buat edit 
    [HttpGet]
    public IActionResult EditPembeli(int id)
    {
        Pembeli pb = _dbContext.Pembelis.First(x=> x.Id == id);
        return View(pb);
    }

    [HttpPost]
    public IActionResult EditPembeli(Pembeli pb)
    {   
        try
            {
                Pembeli updated = _dbContext.Pembelis.First(x => x.Id == pb.Id);
                updated.NamaPembeli = pb.NamaPembeli;
                updated.AlamatPembeli = pb.AlamatPembeli;
                _dbContext.SaveChanges();
                return RedirectToAction("IndexPembeli");
            }
        catch
            {
                return View();
            }
        
    }

    //BUAT USER
    // public IActionResult IndexPembeli()
    // {
    //     List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
    //     return View(pembelis);
    // }
    
    //buat delete 
    // [HttpGet]
    // public IActionResult DeletePembeli(Pembeli pb)
    // {
        
    //     Pembeli deleted = _dbContext.Pembelis.First(x => x.Id == pb.Id);
    //     _dbContext.Pembelis.Remove(deleted);
    //     _dbContext.SaveChanges();
    //      List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
    //     return View("IndexPembeli",pembelis);
    // }

    //input 
    // [HttpGet]
    // public IActionResult InputPembeli()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public IActionResult InputPembeli(Pembeli pb)
    // {   
    //     try
    //         {
    //             // produk.Add(pr);
    //             pb.IdUser = 1;
    //             _dbContext.Pembelis.Add(pb);
    //             _dbContext.SaveChanges();
    //             List<Pembeli> pembelis = _dbContext.Pembelis.ToList();
    //             return View("IndexPembeli",pembelis);
    //             // return View("Index");
    //         }
    //     catch
    //         {
    //             return View("IndexPembeli");
    //         }
        
    // }

    // //buat edit 
    // [HttpGet]
    // public IActionResult EditPembeli(int id)
    // {
    //     Pembeli pb = _dbContext.Pembelis.First(x=> x.Id == id);
    //     return View(pb);
    // }

    // [HttpPost]
    // public IActionResult EditPembeli(Pembeli pb)
    // {   
    //     try
    //         {
    //             Pembeli updated = _dbContext.Pembelis.First(x => x.Id == pb.Id);
    //             updated.NamaPembeli = pb.NamaPembeli;
    //             updated.AlamatPembeli = pb.AlamatPembeli;
    //             _dbContext.SaveChanges();
    //             return RedirectToAction("IndexPembeli");
    //         }
    //     catch
    //         {
    //             return View();
    //         }
        
    // }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
