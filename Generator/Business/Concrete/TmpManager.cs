using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Busines.Concrete
{
	public class TmpManager : ITmpService
	{
		private readonly ITmpRepository _tmpRepository;

		public TmpManager(ITmpRepository tmpRepository)
		{
			_tmpRepository = tmpRepository;
		}

		public void Add(Tmp tmp)
		{
			_tmpRepository.Add(tmp);
		}

		public void Update(Tmp tmp)
		{
			_tmpRepository.Update(tmp);
		}

		public void Delete(Tmp tmp)
		{
			_tmpRepository.Add(tmp);
		}

		public void DeleteAll()
		{
			_tmpRepository.DeleteAll();
		}

		public Tmp Get(int id)
		{
			return _tmpRepository.Get(x => x.Id == id);
		}

		public List<Tmp> GetAll()
		{
			return _tmpRepository.GetAll();
		}
	}
}