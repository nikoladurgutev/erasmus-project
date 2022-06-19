using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IRepository <T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();
        public T Get(Guid? id);
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);

    }
}
