using System;
using System.ComponentModel.DataAnnotations;

namespace RSSApp.Models
{
    public class Building
    {
        public int id { get; set; }
     //   [Display(Name = "Building Name")]

        public string? BuildingName { get; set; }
        public Client Client { get; set; }
       // [Display(Name = "Client")]

        public int ClientID { get; set; }

        public string? Address { get; set; }
    }
}

