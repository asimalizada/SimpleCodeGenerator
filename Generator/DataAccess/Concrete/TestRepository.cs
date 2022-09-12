using Core.DataAccess.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
	public class TestRepository : EfEntityRepositoryBase<Test,Main Context>, IITestRepository
	{
	}
}