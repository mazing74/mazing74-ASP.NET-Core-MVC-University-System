using BLL.Interfaces;
using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class StudentRepository : GenaricRepository<Student>, IstudentRepository
    {
        private  MyAppDbConext _dbcontext;

        public StudentRepository(MyAppDbConext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public MyAppDbConext Get
        {
            get { return _dbcontext; }
        }

     
    }
}
