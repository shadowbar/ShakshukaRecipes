using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.Models.Db;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ModelsMapping _db = new ModelsMapping();

        public ActionResult Index()
        {
            var ingredients = _db.Ingredients.ToList();

            if (ingredients == null)
            {
                return HttpNotFound();
            }

            return View(ingredients);
        }

        [HttpPost]
        public ActionResult Index(List<int> ingredient, List<int> amount)
        {
            for (int i = 0; i < ingredient.Count; i++)
            {

            }

            return RedirectToAction("Index");
        }
    }
}