using ShopQuanAo.DataContext;
using ShopQuanAo.Dto;
using System.Web.Http;

namespace ShopQuanAo.Controllers.Apis
{
    public class SanPhamsController : ApiController
    {
        private ShopQuanAoEntities db = new ShopQuanAoEntities();

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = db.SanPhams.Find(id);

            if (product == null)
                return NotFound();

            db.SanPhams.Remove(product);
            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Add(SanPhamDto sanPham)
        {

            if (sanPham == null)
                return NotFound();

            var newSanPham = new SanPham()
            {
                TenSP = sanPham.TenSanPham,
                GiaMua = sanPham.GiaSanPham
            };

            db.SanPhams.Add(newSanPham);
            db.SaveChanges();

            return Ok(newSanPham.MaSP);
        }


        //public IHttpActionResult Search(string title)
        //{
        //    if (title == null)
        //        return BadRequest("title null");

        //    var products = db.SanPhams.Where(s => s.TenSP.ToLower().Contains(title.ToLower()));

        //    return Ok(products);
        //}
    }
}
