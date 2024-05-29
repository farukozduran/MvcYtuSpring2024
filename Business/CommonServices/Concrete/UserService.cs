using Business.Services.Obs.Abstract;
using Business.Services.Obs.Abstract.CommonInterfaces;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.Dal.Abstract;
using Caching.Abstract;
using System.Net.WebSockets;
using Entities.CommonEntities;
using DataAccess.Dal.Concrete;
using Business.CommonServices.Abstract;

namespace Business.CommonServices.Concrete
{
    public class UserService(IUserDal userDal, ICacheProvider cacheProvider) : IUserService
    {
        public string GetListKey { get; set; } = "";
        public string GetKey { get; set; } = "";

		public User GetUserByEmailAndPassword(string email, string password)
		{
			return userDal.GetUserByEmailAndPassword(email,password);
		}

		public List<OperationClaim> GetUserOperationClaims(int userId)
		{
			return userDal.GetUserOperationClaims(userId);
		}

		//ICacheProvider _cacheProvider = cacheProvider;

		User ICommonDbOperations<User>.Add(User entity)
        {
            cacheProvider.Remove(GetListKey);
            return userDal.Add(entity);
        }

        bool ICommonDbOperations<User>.Any(Expression<Func<User, bool>> filter)
        {
            return userDal.Any(filter);
        }

        User ICommonDbOperations<User>.Get(Expression<Func<User, bool>> filter)
        {
            GetKey = $"Get({filter?.Body})";

            if (!cacheProvider.Any(GetKey))
            {
               // Thread.Sleep(5000);
                var result = userDal.Get(filter);
                cacheProvider.Set(GetKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<User>(GetKey);
        }

        List<User>? ICommonDbOperations<User>.GetList(Expression<Func<User, bool>>? filter)
        {
            GetListKey = $"GetUserList";

            if (!cacheProvider.Any(GetListKey))
            {
                var result = userDal.GetList(filter);
                cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<List<User>>(GetListKey);
        }

        bool ICommonDbOperations<User>.Remove(User entity)
        {
            cacheProvider.Remove(GetListKey);
            return userDal.Remove(entity);
        }

        User ICommonDbOperations<User>.Update(User entity)
        {
            cacheProvider.Remove(GetListKey);
            return userDal.Update(entity);
        }
    }
}
