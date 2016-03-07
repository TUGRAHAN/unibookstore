using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm;
using UniBookStore.Data.Orm.Context;

namespace UniBookStore.Service.Services.Base
{
    public class BaseService<T> : IDisposable where T : BaseEntity
    {
        protected BookStoreEntities db;
        private DbSet<T> _context; // field yarattik ve generic T'yi _context icine gonderdik

        public BaseService()
        {
            db = new BookStoreEntities();
            _context = db.Set<T>();
        }

        public void SaveChanges() // db'ye kaydetme servisi
        {
            db.SaveChanges();
        }

        public List<T>GetAll()  // admin listeleme servisi
        {
            return _context.Where(x=>x.IsDeleted == false).ToList();  
        }

        public List<T> GetAllForFront() // frontuser listeleme servisi
        {
            return _context.Where(x => x.IsDeleted == false && x.IsActive == true).ToList(); 
        }

        public bool ChangeState(int id)  // urun aktif - pasif duzeltme servisi
        {
            var _entity = _context.Find(id);
            _entity.IsActive = !_entity.IsActive;
            SaveChanges();
            return _entity.IsActive;
        }

        public bool Insert(T entity) // ekleme servisi. try catch e attik hata verirse exception gorulsun diye
        {
            try
            {
                _context.Add(entity);
                entity.AddDate = DateTime.Now;
                entity.IsActive = true;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T GetByID(int id) // id yi aliyoruz
        {
            return _context.FirstOrDefault(x => x.IsActive == true && x.IsDeleted == false && x.ID == id);
        }

        public void Delete(int id) // silme servisi
        {
            var _entity = _context.Find(id);
            _entity.IsDeleted = true;
            _entity.IsActive = false;
            _entity.DeleteDate = DateTime.Now;
            SaveChanges();
        }

        public bool Update(T entity) // guncelleme servisi
        {
            var _entity = _context.Find(entity.ID);
            entity.AddDate = _entity.AddDate;
            db.Entry(_entity).CurrentValues.SetValues(entity);
            _entity.UpdateDate = DateTime.Now;
            _entity.IsActive = true;
            SaveChanges();
            return true;
        }

        public List<T> GetLambda(Expression<Func<T, bool>> _lambda)
        {
            return _context.Where(x => x.IsActive == true && x.IsDeleted == false).Where(_lambda).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(db);
        }
    }
}
