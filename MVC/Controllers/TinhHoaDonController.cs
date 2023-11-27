/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;


namespace MVC.Controllers;
public class TinhHoaDonController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index(int IdHD)
    {
        var chiTietHoaDon = ApplicationDbContext.HoaDon.Where(item => item.idHD == idHD).ToList();

        foreach (var item in chiTietHoaDon)
        {
            var sanPham = dbContext.SanPham.FirstOrDefault(sp => sp.MaSanPham == item.MaSanPham);
            item.ThanhTien = sanPham.DonGia * item.SoLuong;
        }

        return View(chiTietHoaDon);
    }
}
 */