using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface ITestService
	{
		void Add(Test test);
		void Update(Test test);
		void Delete(Test test);
		void DeleteAll();
		Test Get(int id);
		List<Test> GetAll();
	}
}