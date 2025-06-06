﻿using RestAPIWithApsNet8.Model.Base;

namespace RestAPIWithApsNet8.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        // method Iterface
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
