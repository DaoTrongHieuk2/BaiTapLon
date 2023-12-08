using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using OfficeOpenXml;

namespace MVC.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDon
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HoaDon.Include(h => h.KhachHang).Include(h => h.NhanVien).Include(h => h.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoaDon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IdHD == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public IActionResult Create()
        {
            ViewData["IdKH"] = new SelectList(_context.KhachHang, "IdKH", "IdKH");
            ViewData["IdNV"] = new SelectList(_context.NhanVien, "IdNV", "IdNV");
            ViewData["IdSP"] = new SelectList(_context.Set<SanPham>(), "IdSP", "IdSP");
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHD,IdKH,IdNV,IdSP,MyProperty")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKH"] = new SelectList(_context.KhachHang, "IdKH", "IdKH", hoaDon.IdKH);
            ViewData["IdNV"] = new SelectList(_context.NhanVien, "IdNV", "IdNV", hoaDon.IdNV);
            ViewData["IdSP"] = new SelectList(_context.Set<SanPham>(), "IdSP", "IdSP", hoaDon.IdSP);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["IdKH"] = new SelectList(_context.KhachHang, "IdKH", "IdKH", hoaDon.IdKH);
            ViewData["IdNV"] = new SelectList(_context.NhanVien, "IdNV", "IdNV", hoaDon.IdNV);
            ViewData["IdSP"] = new SelectList(_context.Set<SanPham>(), "IdSP", "IdSP", hoaDon.IdSP);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdHD,IdKH,IdNV,IdSP,MyProperty")] HoaDon hoaDon)
        {
            if (id != hoaDon.IdHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.IdHD))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKH"] = new SelectList(_context.KhachHang, "IdKH", "IdKH", hoaDon.IdKH);
            ViewData["IdNV"] = new SelectList(_context.NhanVien, "IdNV", "IdNV", hoaDon.IdNV);
            ViewData["IdSP"] = new SelectList(_context.Set<SanPham>(), "IdSP", "IdSP", hoaDon.IdSP);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IdHD == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaDon'  is null.");
            }
            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDon.Remove(hoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(string id)
        {
            return (_context.HoaDon?.Any(e => e.IdHD == id)).GetValueOrDefault();
        }








        public IActionResult Download()
        {
            var fileName = "HoaDonList.xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "IdHD";
                excelWorksheet.Cells["B1"].Value = "IdKH";
                excelWorksheet.Cells["C1"].Value = "IdNV";
                excelWorksheet.Cells["D1"].Value = "IdSP";
                excelWorksheet.Cells["D1"].Value = "MyProperty";
                var psList = _context.HoaDon.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(psList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
