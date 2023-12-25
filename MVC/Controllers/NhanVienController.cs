using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Models.Process;
using OfficeOpenXml;
using X.PagedList;
namespace MVC.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }
        private ExcelProcess _excelPro = new ExcelProcess();

        // GET: NhanVien
       public async Task<IActionResult> Index(int? page, int? PageSize)
        {
            ViewBag.PageSize = new List<SelectListItem>()
        {
            new SelectListItem() { Value="3", Text= "3"},
         new SelectListItem() { Value="5", Text= "5"},
          new SelectListItem() { Value="10", Text= "10"},
           new SelectListItem() { Value="15", Text= "15"},
           new SelectListItem() { Value="25", Text= "25"},
          new SelectListItem() { Value="50", Text= "50"},
        };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.NhanVien.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.IdNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNV,NameNV,AddressNV,PhoneNV,AgeNV")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdNV,NameNV,AddressNV,PhoneNV,AgeNV")] NhanVien nhanVien)
        {
            if (id != nhanVien.IdNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.IdNV))
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
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.IdNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
          return (_context.NhanVien?.Any(e => e.IdNV == id)).GetValueOrDefault();
        }
         public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
                public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file!=null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                    else
                    {
                        //rename file when upload to server
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", "File" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                  //read data from file and write to database
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                for(int i = 0; i < dt.Rows.Count; i++)
                                {
                                    var ps = new NhanVien();
                                    ps.IdNV= dt.Rows[i][0].ToString();
                                    ps.NameNV = dt.Rows[i][1].ToString();
                                    ps.AddressNV = dt.Rows[i][2].ToString();
                                    ps.PhoneNV = dt.Rows[i][3].ToString();
                                    ps.AgeNV = dt.Rows[i][4].ToString();
                                    _context.Add(ps);
                                }
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }                       
                         }
                    }
                 }
           return View();
        }
        public IActionResult Download()
        {
            var fileName = "NhanVien.xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                excelWorksheet.Cells["A1"].Value = "IdNV";
                excelWorksheet.Cells["B1"].Value = "NameNV";
                excelWorksheet.Cells["C1"].Value = "AddressNV";
                excelWorksheet.Cells["D1"].Value = "PhoneNV";
                excelWorksheet.Cells["E1"].Value = "AgeNV";
                var psList = _context.NhanVien.ToList();
                excelWorksheet.Cells["A2"].LoadFromCollection(psList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }

}
