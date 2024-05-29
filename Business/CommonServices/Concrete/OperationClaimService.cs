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
    public class OperationClaimService(IOperationClaimDal operationClaimDal, ICacheProvider cacheProvider) : IOperationClaimService
    {
        public string GetListKey { get; set; } = "";
        public string GetKey { get; set; } = "";
        //ICacheProvider _cacheProvider = cacheProvider;

        OperationClaim ICommonDbOperations<OperationClaim>.Add(OperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return operationClaimDal.Add(entity);
        }

        bool ICommonDbOperations<OperationClaim>.Any(Expression<Func<OperationClaim, bool>> filter)
        {
            return operationClaimDal.Any(filter);
        }

        OperationClaim ICommonDbOperations<OperationClaim>.Get(Expression<Func<OperationClaim, bool>> filter)
        {
            GetKey = $"Get({filter?.Body})";

            if (!cacheProvider.Any(GetKey))
            {
               // Thread.Sleep(5000);
                var result = operationClaimDal.Get(filter);
                cacheProvider.Set(GetKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<OperationClaim>(GetKey);
        }

        List<OperationClaim>? ICommonDbOperations<OperationClaim>.GetList(Expression<Func<OperationClaim, bool>>? filter)
        {
            GetListKey = $"GetOperationClaimList";

            if (!cacheProvider.Any(GetListKey))
            {
                var result = operationClaimDal.GetList(filter);
                cacheProvider.Set(GetListKey, result, TimeSpan.FromSeconds(6000));

                return result;
            }
            return cacheProvider.Get<List<OperationClaim>>(GetListKey);
        }

        bool ICommonDbOperations<OperationClaim>.Remove(OperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return operationClaimDal.Remove(entity);
        }

        OperationClaim ICommonDbOperations<OperationClaim>.Update(OperationClaim entity)
        {
            cacheProvider.Remove(GetListKey);
            return operationClaimDal.Update(entity);
        }
    }
}
