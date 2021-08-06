using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.EsercitazioneWebServices.Core.Repository
{
    public interface IRepository<T>
    {
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
        T GetById(int id);
        List<T> Fetch();

    }
}
