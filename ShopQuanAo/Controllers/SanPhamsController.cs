using ImageResizer;
using PagedList;
using ShopQuanAo.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class SanPhamsController : Controller
    {
        private ShopQuanAoEntities db = new ShopQuanAoEntities();

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var sanPhams = (from s in db.SanPhams
                            select s).OrderByDescending(s => s.MaSP).Include(s => s.LoaiSanPham);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }

        //        // GET: SanPhams
        //        public ActionResult Index()
        //        {
        //            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
        //            return View(sanPhams.ToList());
        //        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams, "Ma", "Ten");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaMua,GiaBan,LoaiSP,ChuDe,ThongTin,GioiTinh,NgayNhapHang")] SanPham sanPham,
            HttpPostedFileBase HinhAnh)
        {

            if (ModelState.IsValid)
            {
                //file upload
                //you can put your existing save code here
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    //do whatever you want with the file
                    //Declare a new dictionary to store the parameters for the image versions.
                    var versions = new Dictionary<string, string>();

                    var path = Server.MapPath("~/Images/");

                    Guid imageName = Guid.NewGuid();

                    //Define the versions to generate
                    versions.Add("small", "maxwidth=200&maxheight=200&format=jpg");
                    versions.Add("medium", "maxwidth=500&maxheight=500&format=jpg");
                    versions.Add("large", "maxwidth=700&maxheight=700&format=jpg");

                    //Generate each version
                    foreach (var suffix in versions.Keys)
                    {
                        HinhAnh.InputStream.Seek(0, SeekOrigin.Begin);

                        //Let the image builder add the correct extension based on the output file type
                        ImageBuilder.Current.Build(
                            new ImageJob(
                                HinhAnh.InputStream,
                                path + suffix + "/" + imageName,
                                new Instructions(versions[suffix]),
                                false,
                                true));
                    }
                    //end file upload
                    sanPham.HinhAnh = imageName + ".jpg";
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams, "Ma", "Ten", sanPham.LoaiSP);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams, "Ma", "Ten", sanPham.LoaiSP);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaMua,GiaBan,LoaiSP,ChuDe,ThongTin,GioiTinh,NgayNhapHang,HinhAnh")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams, "Ma", "Ten", sanPham.LoaiSP);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
