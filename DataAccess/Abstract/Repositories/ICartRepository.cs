﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract.Repositories
{
    public interface ICartRepository:IGenericRepository<Carts>
    { 
    }
}
