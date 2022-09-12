using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface ITempService
	{
		void Add(Temp temp);
		void Update(Temp temp);
		void Delete(Temp temp);
		void DeleteAll();
		Temp Get(int id);
		List<Temp> GetAll();
	}
}