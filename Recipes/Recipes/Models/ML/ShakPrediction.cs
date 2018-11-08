using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Models.ML
{
    public class ShakPrediction
    {
        [ColumnName("Score")]
        public float Rating;
    }
}

