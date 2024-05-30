using Core.Repositories.Ef.DataAccess;
using DataAccess.Dal.Abstract;
using DataAccess.EfDbContext.Obs;
using Entities.CommonEntities;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Concrete
{
    public class UserDal : EfRepositoryBase<User, YtuSchooldDbContext>, IUserDal
    {
		public User GetUserByEmailAndPassword(string email, string password)
		{
			using (YtuSchooldDbContext context = new YtuSchooldDbContext())
			{
				return context.Users!.FirstOrDefault(p=>p.EMail==email && p.Password == password)!;
			}
		}
		public List<OperationClaim> GetUserOperationClaims(int userId)
		{
			using (YtuSchooldDbContext context = new YtuSchooldDbContext())
			{
                return context.UserOperationClaims
                    .Where(p => p.UserId == userId)
                    .Select(p => p.OperationClaim)
                    .ToList()!;
			}
		}
    }
}
