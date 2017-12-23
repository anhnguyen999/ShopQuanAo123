using ShopQuanAo.DataContext;
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
    }
}
