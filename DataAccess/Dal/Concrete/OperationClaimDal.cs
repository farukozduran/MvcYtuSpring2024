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
    public class OperationClaimDal : IOperationClaimDal
    {
        public OperationClaim Add(OperationClaim entity)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.OperationClaims.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<OperationClaim, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.OperationClaims.Any(filter);
            }
        }

        public OperationClaim Get(Expression<Func<OperationClaim, bool>> filter)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.OperationClaims.FirstOrDefault(filter);
            }
        }

        public List<OperationClaim> GetList(Expression<Func<OperationClaim, bool>>? filter = null)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                if(filter == null)
                {
                    return context.OperationClaims.ToList();
                }
                else
                {
                    return context.OperationClaims.Where(filter).ToList();
                }
                
            }
        }

        public bool Remove(OperationClaim entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.OperationClaims.Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public OperationClaim Update(OperationClaim entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.OperationClaims.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
