using System;
using RSSApp.Models;

namespace RSSApp.Services
{
    public interface IInspEquipTestRepository
    {
        Task<List<InspEquipTypeTestRpt>> InspTests(int Inspequipid);

        Task<InspEquipTypeTest> InspTest(int id);

        Task<InspEquipTypeTest> AddNew(InspEquipTypeTest inspEquipTypeTest);
        Task<bool> Update(InspEquipTypeTest inspEquipTypeTest);

        Task<bool> Delete(int id);
    }

}