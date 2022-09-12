using Core.DataAccess.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
	public class TempRepository : EfEntityRepositoryBase<Temp,Main Context>, IITempRepository
	{
	}
}