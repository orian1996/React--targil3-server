using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    //[EnableCors]
    public class IngredientController : ApiController
    {

        //GET: api/Ingredient

        public List<IngredientsDto> Get()
        {
            KitchenDbContext db = new KitchenDbContext();
            var ing = db.Ingredients.Select(x => new IngredientsDto
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Calories = (int)x.Calories,
            }).ToList();
            return ing;
        }


        // POST: api/Ingredient
        public IHttpActionResult Post([FromBody] Ingredient value)
        {
            try
            {
                KitchenDbContext db = new KitchenDbContext();
                db.Ingredients.Add(value);
                db.SaveChanges();
                return Created(new Uri(Request.RequestUri.AbsoluteUri), value);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

       
    }
}
