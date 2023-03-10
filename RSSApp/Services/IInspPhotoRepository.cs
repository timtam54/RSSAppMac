using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IInspPhotoRepository
    {
		Task<List<InspPhoto>> InspPhotos(int Inspequipid);
//        Task<InspEquip> InspItem(int Inspequipid);

    }
}

