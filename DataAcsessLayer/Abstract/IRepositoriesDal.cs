﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract
{
    public interface IRepositoriesDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllFilter(Expression<Func<T, bool>> filter);
        T GetByFilter(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        List<T> GetAllFilterInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);



    }
}
