﻿using Business.Services.Obs.Abstract.CommonInterfaces;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Obs.Abstract
{
    public interface IDepartmentService:ICommonDbOperations<Department>
    {
    }
}
