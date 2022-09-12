using Core.DataAccess.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
	public class TmpRepository : EfEntityRepositoryBase<Tmp,Main Context>, IITmpRepository
	{
	}
}