using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IClientRepository
    {
		Task<List<Client>> Clients();
	}
}

