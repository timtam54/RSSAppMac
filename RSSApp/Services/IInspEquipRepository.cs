using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IInspEquipRepository
    {
		Task<List<InspEquipView>> InspItems(int Inspectionid);
        Task<InspEquip> InspItem(int Inspequipid);

        Task<InspEquip> AddNew(InspEquip inspEquip);
        Task<bool> Update(InspEquip inspEquip);

        Task<bool> Delete(int id);
    }
}

