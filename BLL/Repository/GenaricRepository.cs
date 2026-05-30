using BLL.Interfaces;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly MyAppDbConext _dbcontext;

        public GenaricRepository(MyAppDbConext dbcontext )
        {
            _dbcontext = dbcontext;
        }
        public int add(T entity)
        {
             _dbcontext.Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int delete(T entity)
        {
            _dbcontext.Remove(entity);
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T)==typeof(Student))
            {
                return _dbcontext.Students.Include(d=> d.Department).Include(s => s.StudentCourses).ThenInclude(c => c.Course).ToList() as IEnumerable<T>;
            }

            return _dbcontext.Set<T>().ToList();
        }
        public T GetById(int id) => _dbcontext.Set<T>().Find(id);
        
        public int update(T entity)
        {
            _dbcontext.Update(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
