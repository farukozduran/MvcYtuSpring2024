﻿using Core.Repositories.Ef.DataAccess;
using DataAccess.Dal.Abstract;
using DataAccess.EfDbContext.Obs;
using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dal.Concrete
{
    public class FacultyDal :EfRepositoryBase<Faculty,YtuSchooldDbContext> ,IFacultyDal
    {
       
    }
}
