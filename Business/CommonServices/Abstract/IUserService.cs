using Business.Services.Obs.Abstract.CommonInterfaces;
using Entities.CommonEntities;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CommonServices.Abstract
{
    public interface IUserService:ICommonDbOperations<User>
    {
		User GetUserByEmailAndPassword(string email, string password);
		List<OperationClaim> GetUserOperationClaims(int userId);
	}
}
