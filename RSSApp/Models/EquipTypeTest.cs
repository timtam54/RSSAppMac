using System;
namespace RSSApp.Models
{
    public class EquipTypeTest
    {

        public int id { get; set; }
        public int? EquipTypeID { get; set; }
        public string? Test { get; set; }
        public int? Severity { get; set; }

        public EquipType? EquipType { get; set; }
    }
}