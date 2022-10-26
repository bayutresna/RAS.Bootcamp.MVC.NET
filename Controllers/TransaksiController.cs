using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.MVC.NET.Models;
using RAS.Bootcamp.MVC.NET.Models.Entity;
using RAS.Bootcamp.MVC.NET.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RAS.Bootcamp.MVC.NET.Controllers;

public class TransaksiController : Controller
{
    private readonly dbcontext _dbContext;

    private readonly ILogger<TransaksiController> _logger;

    public TransaksiController(ILogger<TransaksiController> logger, dbcontext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult DataTransaksi(){
        if (User.IsInRole("Penjual")){
            int datauserid = int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
            Penjual pj = _dbContext.Penjuals.First(x=> x.IdUser == datauserid);
            var tr = (from a in _dbContext.Transaksis
                            join b in _dbContext.ItemTransaksis on a.Id equals b.IdTransaksi
                            join c in _dbContext.Barangs on b.IdBarang equals c.Id
                            where c.IdPenjual == pj.Id
                            group a by a.Id into transaksi
                            select transaksi.FirstOrDefault()).ToList(); 
            return View(tr); 
        }
        List<Transaksi> alltr = _dbContext.Transaksis.ToList();
        return View(alltr);
    }
    public IActionResult DetailTransaksi(int id){
        var tr = _dbContext.Transaksis.First(x=> x.Id == id);
        var pb = _dbContext.Pembelis.First(x=> x.IdUser == tr.IdUser);

        RequestTransaksi reqtr = new RequestTransaksi{
            namapembeli = pb.NamaPembeli,
            TotalHarga = tr.TotalHarga,
            MetodePembayaran = tr.MetodePembayaran,
            StatusTransaksi = tr.StatusTransaksi,
            AlamatPengiriman = tr.AlamatPengiriman,
            StatusBayar = tr.StatusBayar,
            Id = tr.Id
        };
        return View(reqtr);
    }

    public IActionResult Pembayaran(int id){
        var tr = _dbContext.Transaksis.First(x=> x.Id == id);
        tr.StatusBayar = "Lunas";
        tr.StatusTransaksi = "Diproses";
        _dbContext.SaveChanges();
        List<Transaksi> alltr = _dbContext.Transaksis.ToList();
        return View("DataTransaksi",alltr);
    }
    public IActionResult BatalTransaksi(int id){
        var tr = _dbContext.Transaksis.First(x=> x.Id == id);
        tr.StatusBayar = "Dibatalkan";
        tr.StatusTransaksi = "Dibatalkan";
        _dbContext.SaveChanges();
        int datauserid = int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
            Penjual pj = _dbContext.Penjuals.First(x=> x.IdUser == datauserid);
            var atr = (from a in _dbContext.Transaksis
                            join b in _dbContext.ItemTransaksis on a.Id equals b.IdTransaksi
                            join c in _dbContext.Barangs on b.IdBarang equals c.Id
                            where c.IdPenjual == pj.Id
                            group a by a.Id into transaksi
                            select transaksi.FirstOrDefault()).ToList(); 
            return View("DataTransaksi",atr); 
    }
    public IActionResult KirimBarang (int id){
        var tr = _dbContext.Transaksis.First(x=> x.Id == id);
        tr.StatusTransaksi = "Dikirim";
        _dbContext.SaveChanges();
        int datauserid = int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
            Penjual pj = _dbContext.Penjuals.First(x=> x.IdUser == datauserid);
            var atr = (from a in _dbContext.Transaksis
                            join b in _dbContext.ItemTransaksis on a.Id equals b.IdTransaksi
                            join c in _dbContext.Barangs on b.IdBarang equals c.Id
                            where c.IdPenjual == pj.Id
                            group a by a.Id into transaksi
                            select transaksi.FirstOrDefault()).ToList(); 
            return View("DataTransaksi",atr); 
    }
}