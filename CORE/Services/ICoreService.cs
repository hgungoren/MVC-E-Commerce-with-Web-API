using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services
{
    public interface ICoreService<T> where T : EntityRepository
    {
        //Ekleme
        void Add(T model);

        //Liste Olarak ekleme
        void Add(List<T> models);

        //Tekil olarak getirme
        T GetById(Guid id);

        //Geriye liste halinde verilerin dönmesi
        List<T> GetAll();

        //Silme
        void Remove(Guid id);

        //Güncelleme
        void Update(T model);

        //Kriter 
        //x=>x.id==id
        List<T> GetDefault(Expression<Func<T, bool>> exp);

        T GetSingle(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);

        List<T> GetActive();

    }
}
