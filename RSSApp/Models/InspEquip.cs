using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RSSApp.Models
{

    public class InspEquipViewModel
    {
        public string TestingInstruments { get; set; }
        public string Areas { get; set; }
        public string InspectionDate { get; set; }
        public ObservableCollection<InspEquipView> InspEquipViews { get; set; }
    }

    public class InspEquip
     {
        public List<SelectListItem> Et { get; set; }
        public SelectListItem SelEquipType { get; set; }

        public int id { get; set; }
         [Display(Name = "Type")]
         public int EquipTypeID { get; set; }
         [Display(Name = "Inspection")]
         public int InspectionID { get; set; }
         public string? Location { get; set; }
         public string? Notes { get; set; }

         public Inspection? Inspection { get; set; }
        // public EquipType? EquipType { get; set; }

         public string? Manufacturer { get; set; }
         public string? Installer { get; set; }
         public string? Rating { get; set; }
         public string? SerialNo { get; set; }
         public DateTime? WithdrawalDate { get; set; }
      //   public List<InspPhoto>? Photos { get; set; }
     }
    public class InspEquipView
    {
        public int id { get; set; }
        [Display(Name = "Type")]
        public string? EquipDesc { get; set; }
        public int InspectionID { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public string? Photos { get; set; }

        public string? Manufacturer { get; set; }
        public string? Installer { get; set; }
        public string? Rating { get; set; }
        public string? SerialNo { get; set; }
        public DateTime? WithdrawalDate { get; set; }

    }



}

