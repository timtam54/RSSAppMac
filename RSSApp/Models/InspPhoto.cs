﻿using System;
using System.Collections.ObjectModel;

namespace RSSApp.Models
{

    public class InspPhotoViewModel
    {
        public ObservableCollection<InspectionView> InspPhotos { get; set; }
    }

    public class InspPhoto
    {
        public int id { get; set; }
        public int InspEquipID { get; set; }
        public string photoname { get; set; }
        public string? description { get; set; }
    }
}

