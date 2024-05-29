using DataAccess.Dal.CommonOperations;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Abstract
{
    public interface IDepartmentDal:ICommonDal<Department>
    {
        // special methods for department.
    }
}
