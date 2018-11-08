
using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Models;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ShaksukaModelTrainer
{
    class ShakModelTrainer
    {
        static readonly string _datapath = Path.Combine(Environment.CurrentDirectory, "Data", "shak-train.csv");
        static readonly string _testdatapath = Path.Combine(Environment.CurrentDirectory, "Data", "shak-test.csv");
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
        public static async Task Main(string[] args)
        {
            string arg;
            Console.WriteLine("enter #train, #eval or #predict");
            arg = Console.ReadLine();

            if (arg == "train")
            {
                PredictionModel<ShakVector, ShakPrediction> model = await Train();
                System.Threading.Thread.Sleep(3000);

            }
            else if (arg == "eval")
            {
                PredictionModel<ShakVector, ShakPrediction> model = await PredictionModel.ReadAsync<ShakVector, ShakPrediction>(_modelpath);
                System.Threading.Thread.Sleep(3000);
                Evaluate(model);
            }
            else if (arg == "predict")
            {
                PredictionModel<ShakVector, ShakPrediction> model = await PredictionModel.ReadAsync<ShakVector, ShakPrediction>(_modelpath);
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Write ingridiants:");
                string Tomato, Onion, Garlic, BellPepper, Eggs, Pepper, Salt, BulgerianCheese, Paprika, Water, Resek, Cumun, Eggplant, Tofu, FryingTimeBeforeTomatosMinutes, CookingAfterTomatosMinutes, CookingAfterEggsMinutes;

                Tomato = Console.ReadLine();
                Onion = Console.ReadLine();
                Garlic = Console.ReadLine();
                BellPepper = Console.ReadLine();
                Eggs = Console.ReadLine();
                Pepper = Console.ReadLine();
                Salt = Console.ReadLine();
                BulgerianCheese = Console.ReadLine();
                Paprika = Console.ReadLine();
                Water = Console.ReadLine();
                Resek = Console.ReadLine();
                Cumun = Console.ReadLine();
                Eggplant = Console.ReadLine();
                Tofu = Console.ReadLine();
                FryingTimeBeforeTomatosMinutes = Console.ReadLine();
                CookingAfterTomatosMinutes = Console.ReadLine();
                CookingAfterEggsMinutes = Console.ReadLine();
                ShakVector newVec = new ShakVector
                {
                    TomatoAmount = float.Parse(Tomato),
                    OnionAmount = float.Parse(Onion),
                    GarlicAmount = float.Parse(Garlic),
                    BellPepperAmount = float.Parse(BellPepper),
                    EggsAmount = float.Parse(Eggs),
                    PepperAmount = float.Parse(Pepper),
                    SaltAmount = float.Parse(Salt),
                    BulgerianCheeseAmount = float.Parse(BulgerianCheese),
                    PaprikaAmount = float.Parse(Paprika),
                    WaterAmount = float.Parse(Water),
                    TomatoResekAmount = float.Parse(Resek),
                    CuminAmount = float.Parse(Cumun),
                    EggplantAmount = float.Parse(Eggplant),
                    TofuAmount = float.Parse(Tofu),
                    FryingTimeBeforeTomatosMinutes = float.Parse(FryingTimeBeforeTomatosMinutes),
                    CookingAfterEggsMinutes = float.Parse(CookingAfterEggsMinutes),
                    CookingAfterTomatosMinutes = float.Parse(CookingAfterTomatosMinutes)


                };
                Predict(model, newVec);
            }
        }

        private static void Predict(PredictionModel<ShakVector, ShakPrediction> model, ShakVector newVec)
        {
            ShakPrediction prediction = model.Predict(newVec);
            Console.WriteLine("Predicted fare: {0}", prediction.Rating);
            Console.ReadLine();
        }

        public static async Task<PredictionModel<ShakVector, ShakPrediction>> Train()
        {
            var pipeline = new LearningPipeline
            {
                new TextLoader(_datapath).CreateFrom<ShakVector>(useHeader: true, separator: ','),
                new ColumnCopier(("Rating", "Label")),
                new ColumnConcatenator(
                    "Features",
                    "TomatoAmount",
                    "OnionAmount",
                    "GarlicAmount",
                    "BellPepperAmount",
                    "EggsAmount",
                    "PepperAmount",
                    "SaltAmount",
                    "BulgerianCheeseAmount",
                    "PaprikaAmount",
                    "WaterAmount",
                    "TomatoResekAmount",
                    "CuminAmount",
                    "EggplantAmount",
                    "TofuAmount",
                    "FryingTimeBeforeTomatosMinutes",
                    "CookingAfterTomatosMinutes",
                    "CookingAfterEggsMinutes"),
                new FastTreeRegressor()
            };

            PredictionModel<ShakVector, ShakPrediction> model = pipeline.Train<ShakVector, ShakPrediction>();
            await model.WriteAsync(_modelpath);
            return model;
        }

        private static void Evaluate(PredictionModel<ShakVector, ShakPrediction> model)
        {
            var testData = new TextLoader(_testdatapath).CreateFrom<ShakVector>(useHeader: true, separator: ',');

            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);
            Console.WriteLine($"RSquared = {metrics.RSquared}");
            Console.ReadLine();
        }
    }
}
