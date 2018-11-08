using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShaksukaModelTrainer
{
    public class ShakPrediction
    {
        [ColumnName("Score")]
        public float Rating;
    }
}

