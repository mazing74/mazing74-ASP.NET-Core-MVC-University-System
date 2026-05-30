using BLL.Interfaces;
using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MyAppDbConext dbcontext) : base(dbcontext)
        {
        }
    }
}
