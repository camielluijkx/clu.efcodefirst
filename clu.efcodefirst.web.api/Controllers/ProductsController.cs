using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using clu.efcodefirst.web.api.Mapping;
using clu.efcodefirst.web.api.Models;

namespace clu.efcodefirst.web.api.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductReviewMapper productReviewMapper;

        private ProductReviewsContext db = new ProductReviewsContext();

        public ProductsController() // [TODO] improve ioc setup
        {
            productReviewMapper = new ProductReviewMapper();
            productReviewMapper.Configure();
        }

        // GET: api/Products
        [ResponseType(typeof(IList<ProductDetailsDto>))]
        public async Task<IHttpActionResult> GetProductsAsync()
        {
            IQueryable<Product> products = db.Products
                .Include(p => p.Reviews);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(productReviewMapper.Map<IList<ProductDetailsDto>>(products));
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductDetailsDto))]
        public async Task<IHttpActionResult> GetProductAsync(int id)
        {
            Product product = await db.Products
                .FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(productReviewMapper.Map<ProductDetailsDto>(product));
        }

        // POST: api/Products
        [ResponseType(typeof(ProductDetailsDto))]
        public async Task<IHttpActionResult> PostProductAsync(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId },
                productReviewMapper.Map<ProductDetailsDto>(product));
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductAsync(int id, ProductDetailsDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //try
            //{
            //    db.Entry(productReviewMapper.Map<Product>(product)).State = EntityState.Modified;
            //}
            //catch (Exception ex)
            //{
            //    if (!ProductExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductDetailsDto))]
        public async Task<IHttpActionResult> DeleteProductAsync(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(productReviewMapper.Map<ProductDetailsDto>(product));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}