using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models.Db;
using Recipes.Models.ML;
using Microsoft.ML.Legacy;

namespace Recipes.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ModelsMapping _db = new ModelsMapping();
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

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
        public async Task<ActionResult> Index(List<int> ingredient, List<int> amount)
        {
            PredictionModel<ShakVector, ShakPrediction> model = await PredictionModel.ReadAsync<ShakVector, ShakPrediction>(_modelpath);

            ShakVector newVec = new ShakVector
            {
                TomatoAmount = amount[0],
                OnionAmount = amount[1],
                GarlicAmount = amount[2],
                BellPepperAmount = amount[3],
                EggsAmount = amount[4],
                PepperAmount = amount[5],
                SaltAmount = amount[6],
                BulgerianCheeseAmount = amount[7],
                PaprikaAmount = amount[8],
                WaterAmount = amount[9],
                TomatoResekAmount = amount[10],
                CuminAmount = amount[11],
                EggplantAmount = amount[12],
                TofuAmount = amount[13],
                FryingTimeBeforeTomatosMinutes = amount[14],
                CookingAfterEggsMinutes = amount[15],
                CookingAfterTomatosMinutes = amount[16]
            };

            ShakPrediction prediction = model.Predict(newVec);

            return View("Prediction", prediction.Rating);
        }
    }
}