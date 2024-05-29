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
    public class UserDal : IUserDal
    {
        public User Add(User entity)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<User, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Users.Any(filter);
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Users.FirstOrDefault(filter);
            }
        }

		public User GetUserByEmailAndPassword(string email, string password)
		{
			using (YtuSchooldDbContext context = new YtuSchooldDbContext())
			{
				return context.Users!.FirstOrDefault(p=>p.EMail==email && p.Password == password)!;
			}
		}

		public List<User> GetList(Expression<Func<User, bool>>? filter = null)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                if(filter == null)
                {
                    return context.Users.ToList();
                }
                else
                {
                    return context.Users.Where(filter).ToList();
                }
                
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

		public bool Remove(User entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Users.Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public User Update(User entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Users.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
