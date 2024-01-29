using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> List { get; }
        Task Create(T p);
    }
}