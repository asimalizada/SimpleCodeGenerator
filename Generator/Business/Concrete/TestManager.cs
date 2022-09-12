using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Busines.Concrete
{
	public class TestManager : ITestService
	{
		private readonly ITestRepository _testRepository;

		public TestManager(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}

		public void Add(Test test)
		{
			_testRepository.Add(test);
		}

		public void Update(Test test)
		{
			_testRepository.Update(test);
		}

		public void Delete(Test test)
		{
			_testRepository.Add(test);
		}

		public void DeleteAll()
		{
			_testRepository.DeleteAll();
		}

		public Test Get(int id)
		{
			return _testRepository.Get(x => x.Id == id);
		}

		public List<Test> GetAll()
		{
			return _testRepository.GetAll();
		}
	}
}