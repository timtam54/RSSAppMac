using System;
using System.ComponentModel.DataAnnotations;

namespace RSSApp.Models
{
    public class EquipType
    {
        //https://roofsafetysolutions.azurewebsites.net/api/EquipTypes
     

              public int id { get; set; }
        [Display(Name = "Equipment Type")]
        public string? EquipTypeDesc { get; set; }
    }
}

