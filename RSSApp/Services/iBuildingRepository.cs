using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IBuildingRepository
    {
		Task<List<Building>> Buildings();
	}
}

