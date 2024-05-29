using DataAccess.Dal.CommonOperations;
using Entities.CommonEntities;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Abstract
{
    public interface IUserDal:ICommonDal<User>
    {
        User GetUserByEmailAndPassword(string email, string password);
        List<OperationClaim> GetUserOperationClaims(int userId);
    }
}
