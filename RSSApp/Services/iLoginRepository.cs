using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface ILoginRepository
	{
		Task<Employee> Login(string email,string password);
	}
}

