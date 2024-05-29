using DataAccess.Dal.Abstract;
using DataAccess.EfDbContext.Obs;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Concrete
{
    public class DepartmentDal :IDepartmentDal
    {
        public Department Add(Department entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Departments.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<Department, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Departments.Any(filter);
            }
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Departments.FirstOrDefault(filter);
            }
        }

        public List<Department> GetList(Expression<Func<Department, bool>>? filter = null)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                if (filter == null)
                {
                    return context.Departments.ToList();
                }
                else
                {
                    return context.Departments.Where(filter).ToList();
                }
            }
        }

        public bool Remove(Department entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Departments.Remove(entity);
                context.SaveChanges();

                return true;
            }
        }

        public Department Update(Department entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Departments.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
