using Core.Repositories.CommonInterfaces;
using Entities.CommonEntities;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Abstract
{
    public interface IUserDal: IRepositoryBase<User>
    {
        User GetUserByEmailAndPassword(string email, string password);
        List<OperationClaim> GetUserOperationClaims(int userId);
    }
}
