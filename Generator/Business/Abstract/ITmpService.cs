using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface ITmpService
	{
		void Add(Tmp tmp);
		void Update(Tmp tmp);
		void Delete(Tmp tmp);
		void DeleteAll();
		Tmp Get(int id);
		List<Tmp> GetAll();
	}
}