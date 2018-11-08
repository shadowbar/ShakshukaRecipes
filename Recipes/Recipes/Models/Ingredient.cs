using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Models
{
    public class Ingredient : BaseModel
    {
        [Required]
        [DisplayName("Ingredient")]
        public string Name { get; set; }
    }
}