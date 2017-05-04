using System.Linq;
using NTERPCloud.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NTERPCloud.Business.Products;

namespace NTERPCloud.Controller
{
    [Route("api/[controller]")]
    public class ProductsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        // problems with cache
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_products.GetAll());
        }

        [HttpPost]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_products.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product newThing = _products.Add(product);

            return CreatedAtRoute("GetSingleThing", new { id = newThing.Id }, newThing);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            Product existingEntity = _products.GetSingle(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            Product product = existingEntity;
            patchDoc.ApplyTo(product, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedThing = _products.Update(id, product);

            return Ok(updatedThing);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSingleThing")]
        public IActionResult Single(int id)
        {
            Product product = _products.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            Product product = _products.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            _products.Delete(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]Product product)
        {
            var thingToCheck = _products.GetSingle(id);

            if (thingToCheck == null)
            {
                return NotFound();
            }

            if (id != product.Id)
            {
                return BadRequest("Ids do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedThing = _products.Update(id, product);

            return Ok(updatedThing);
        }
    }
}
