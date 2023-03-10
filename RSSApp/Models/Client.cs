﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RSSApp.Models
{
    public class Client
    {
        public int id { get; set; }
//        [Display(Name = "Name")]
        public string? name { get; set; }
        public string? Address { get; set; }
        public string? ContactName { get; set; }

      //  [Display(Name = "Started Date")]

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

       // [DataType(DataType.Date)]

        public DateTime StartedDate { get; set; }

        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }

    }

}

