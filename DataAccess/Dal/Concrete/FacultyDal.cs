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
    public class FacultyDal : IFacultyDal
    {
        public Faculty Add(Faculty entity)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Faculties.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Any(Expression<Func<Faculty, bool>> filter)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Faculties.Any(filter);
            }
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter)
        {
            using(YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                return context.Faculties.FirstOrDefault(filter);
            }
        }

        public List<Faculty> GetList(Expression<Func<Faculty, bool>>? filter = null)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                if(filter == null)
                {
                    return context.Faculties.ToList();
                }
                else
                {
                    return context.Faculties.Where(filter).ToList();
                }
                
            }
        }

        public bool Remove(Faculty entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Faculties.Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public Faculty Update(Faculty entity)
        {
            using (YtuSchooldDbContext context = new YtuSchooldDbContext())
            {
                context.Faculties.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
