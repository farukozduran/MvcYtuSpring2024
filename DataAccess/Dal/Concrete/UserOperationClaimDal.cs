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
    public class UserOperationClaimDal : IUserOperationClaimDal
    {
        public UserOperationClaim Add(UserOperationClaim entity)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.UserOperationClaims.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<UserOperationClaim, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.UserOperationClaims.Any(filter);
            }
        }

        public UserOperationClaim Get(Expression<Func<UserOperationClaim, bool>> filter)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.UserOperationClaims.FirstOrDefault(filter);
            }
        }

        public List<UserOperationClaim> GetList(Expression<Func<UserOperationClaim, bool>>? filter = null)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                if(filter == null)
                {
                    return context.UserOperationClaims.ToList();
                }
                else
                {
                    return context.UserOperationClaims.Where(filter).ToList();
                }
                
            }
        }

        public bool Remove(UserOperationClaim entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.UserOperationClaims.Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public UserOperationClaim Update(UserOperationClaim entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.UserOperationClaims.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
