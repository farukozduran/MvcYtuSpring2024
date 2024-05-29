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
    public class UserOperationClaimService(IUserOperationClaimDal userOperationClaimDal, ICacheProvider cacheProvider) : IUserOperationClaimService
    {
        public string GetListKey { get; set; } = "";
        public string GetKey { get; set; } = "";
        //ICacheProvider _cacheProvider = cacheProvider;

        UserOperationClaim ICommonDbOperations<UserOperationClaim>.Add(UserOperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return userOperationClaimDal.Add(entity);
        }

        bool ICommonDbOperations<UserOperationClaim>.Any(Expression<Func<UserOperationClaim, bool>> filter)
        {
            return userOperationClaimDal.Any(filter);
        }

        UserOperationClaim ICommonDbOperations<UserOperationClaim>.Get(Expression<Func<UserOperationClaim, bool>> filter)
        {
            GetKey = $"Get({filter?.Body})";

            if (!cacheProvider.Any(GetKey))
            {
               // Thread.Sleep(5000);
                var result = userOperationClaimDal.Get(filter);
                cacheProvider.Set(GetKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<UserOperationClaim>(GetKey);
        }

        List<UserOperationClaim>? ICommonDbOperations<UserOperationClaim>.GetList(Expression<Func<UserOperationClaim, bool>>? filter)
        {
            GetListKey = $"GetUserOperationClaimList";

            if (!cacheProvider.Any(GetListKey))
            {
                var result = userOperationClaimDal.GetList(filter);
                cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<List<UserOperationClaim>>(GetListKey);
        }

        bool ICommonDbOperations<UserOperationClaim>.Remove(UserOperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return userOperationClaimDal.Remove(entity);
        }

        UserOperationClaim ICommonDbOperations<UserOperationClaim>.Update(UserOperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return userOperationClaimDal.Update(entity);
        }
    }
}
