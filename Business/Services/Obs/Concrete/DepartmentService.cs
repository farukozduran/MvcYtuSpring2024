using Business.Services.Obs.Abstract;
using Business.Services.Obs.Abstract.CommonInterfaces;
using DataAccess.Dal.Abstract;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Obs.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentService(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        Department ICommonDbOperations<Department>.Add(Department entity)
        {
            return _departmentDal.Add(entity);
        }

        bool ICommonDbOperations<Department>.Any(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.Any(filter);
        }

        Department ICommonDbOperations<Department>.Get(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.Get(filter);
        }

        List<Department> ICommonDbOperations<Department>.GetList(Expression<Func<Department, bool>>? filter)
        {
            return _departmentDal.GetList(filter);
        }

        bool ICommonDbOperations<Department>.Remove(Department entity)
        {
            return _departmentDal.Remove(entity);
        }

        Department ICommonDbOperations<Department>.Update(Department entity)
        {
            return _departmentDal.Update(entity);
        }
    }
}
