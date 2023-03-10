using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IEquipTypeTestRepository
    {
		Task<List<EquipTypeTest>> EquipTypeTests(int EquipTypeID);


        Task<EquipTypeTest> InspItem(int EquipTypeID);

        Task<EquipTypeTest> AddNew(EquipTypeTest equipTypeTest);
        Task<bool> Update(EquipTypeTest equipTypeTest);

        Task<bool> Delete(int id);
    }
}

