using Business.Services.Obs.Abstract;
using Business.Services.Obs.Abstract.CommonInterfaces;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.Dal.Abstract;
using Caching.Abstract;
using System.Net.WebSockets;

namespace Business.Services.Obs.Concrete
{
    public class FacultyService(IFacultyDal facultyDal, ICacheProvider cacheProvider) : IFacultyService
    {
        public string GetListKey { get; set; } = "";
        public string GetKey { get; set; } = "";
        //ICacheProvider _cacheProvider = cacheProvider;

        Faculty ICommonDbOperations<Faculty>.Add(Faculty entity)
        {
            cacheProvider.Remove(GetListKey);
            return facultyDal.Add(entity);
        }

        bool ICommonDbOperations<Faculty>.Any(Expression<Func<Faculty, bool>> filter)
        {
            return facultyDal.Any(filter);
        }

        Faculty ICommonDbOperations<Faculty>.Get(Expression<Func<Faculty, bool>> filter)
        {
            GetKey = $"Get({filter?.Body})";

            if (!cacheProvider.Any(GetKey))
            {
               // Thread.Sleep(5000);
                var result = facultyDal.Get(filter);
                cacheProvider.Set(GetKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<Faculty>(GetKey);
        }

        List<Faculty>? ICommonDbOperations<Faculty>.GetList(Expression<Func<Faculty, bool>>? filter)
        {
            GetListKey = $"GetFacultyList";

            if (!cacheProvider.Any(GetListKey))
            {
                var result = facultyDal.GetList(filter);
                cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<List<Faculty>>(GetListKey);
        }

        bool ICommonDbOperations<Faculty>.Remove(Faculty entity)
        {
            cacheProvider.Remove(GetListKey);
            return facultyDal.Remove(entity);
        }

        Faculty ICommonDbOperations<Faculty>.Update(Faculty entity)
        {
            cacheProvider.Remove(GetListKey);
            return facultyDal.Update(entity);
        }
    }
}
