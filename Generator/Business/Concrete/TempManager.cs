using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Busines.Concrete
{
	public class TempManager : ITempService
	{
		private readonly ITempRepository _tempRepository;

		public TempManager(ITempRepository tempRepository)
		{
			_tempRepository = tempRepository;
		}

		public void Add(Temp temp)
		{
			_tempRepository.Add(temp);
		}

		public void Update(Temp temp)
		{
			_tempRepository.Update(temp);
		}

		public void Delete(Temp temp)
		{
			_tempRepository.Add(temp);
		}

		public void DeleteAll()
		{
			_tempRepository.DeleteAll();
		}

		public Temp Get(int id)
		{
			return _tempRepository.Get(x => x.Id == id);
		}

		public List<Temp> GetAll()
		{
			return _tempRepository.GetAll();
		}
	}
}