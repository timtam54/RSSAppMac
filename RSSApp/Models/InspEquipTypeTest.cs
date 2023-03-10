using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace RSSApp.Models
{

    public class InspEquipTypeTestViewModel
    {
        public List<InspEquipTypeTestRpt> InspEquipTypeTests { get; set; }//ObservableCollection
    }

    public class InspEquipTypeTest
    {
        public int id { get; set; }

        public int InspEquipID { get; set; }

        public int EquipTypeTestID { get; set; }

        public bool Pass { get; set; }

        public string? Reason { get; set; }

        public List<SelectListItem> Ett { get; set; }
        public SelectListItem SelEquipTypeTest { get; set; }
    }

    public class InspEquipTypeTestRpt
    {
        public int id { get; set; }

        public int InspEquipID { get; set; }

        public String EquipTypeTest { get; set; }

        public bool Pass { get; set; }

        public string? Reason { get; set; }

        //public List<SelectListItem> Ett { get; set; }
       // public SelectListItem SelEquipTypeTest { get; set; }
    }
}

