using System;
using RSSApp.Models;

namespace RSSApp.Services
{
    public interface IInspectionRepository
    {
        Task<List<InspectionView>> Inspections();
        Task<Inspection> Inspection(int id);
        Task<Inspection> AddNew(Inspection inspection);
        Task<bool> Update(Inspection inspection);
        Task<bool> Delete(int id);
    }
}