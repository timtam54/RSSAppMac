using System;
using RSSApp.Models;

namespace RSSApp.Services
{
	public interface IEmployeeRepository
    {
		Task<List<Employee>> Employees();
	}
}

