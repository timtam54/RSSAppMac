using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IEquipTypeRepository
    {
		Task<List<EquipType>> EquipTypes();
	}
}

