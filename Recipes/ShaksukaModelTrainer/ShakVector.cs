using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;
using Microsoft.ML.Runtime.Api;

namespace ShaksukaModelTrainer
{
    public class ShakVector
    {
        [Column("0")]
        public float TomatoAmount;

        [Column("1")]
        public float OnionAmount;

        [Column("2")]
        public float GarlicAmount;

        [Column("3")]
        public float BellPepperAmount;

        [Column("4")]
        public float EggsAmount;

        [Column("5")]
        public float PepperAmount;

        [Column("6")]
        public float SaltAmount;

        [Column("7")]
        public float BulgerianCheeseAmount;

        [Column("8")]
        public float PaprikaAmount;

        [Column("9")]
        public float WaterAmount;

        [Column("10")]
        public float TomatoResekAmount;

        [Column("11")]
        public float CuminAmount;

        [Column("12")]
        public float EggplantAmount;

        [Column("13")]
        public float TofuAmount;

        [Column("14")]
        public float FryingTimeBeforeTomatosMinutes;

        [Column("15")]
        public float CookingAfterTomatosMinutes;

        [Column("16")]
        public float CookingAfterEggsMinutes;

        [Column("17")]
        public float Rating;
    }
}
