using CORE.CoreEntity;
using CORE.Services;
using MODEL.Context;
using SERVICE.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {

        AppDbContext db = Singleton.Context;
        public void Add(T model)
        {
            model.ID = Guid.NewGuid();

            db.Set<T>().Add(model);
            db.SaveChanges();
        }

        public void Add(List<T> models)
        {
            db.Set<T>().AddRange(models);
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Status == CORE.CoreEntity.Enums.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = CORE.CoreEntity.Enums.Status.Deleted;
            Update(item);

        }


        public void Update(T model)//chai
        {
            T updated = GetById(model.ID);//chang
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(model);
            db.SaveChanges();
        }
    }
}
