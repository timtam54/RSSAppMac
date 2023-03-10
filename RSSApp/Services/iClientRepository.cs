using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IClient
	{
		Task<List<Client>> Clients();
	}
}

