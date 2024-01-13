using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    //bağımlılıkları kontrol etmek için interfaceler kullanılır
    //istediğimiz bir tip verebiliriz
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);  
        //yazılan sorgular veritabanına gitmez.Order By Group By sorguları için varlar.
        IQueryable<T> GetAll();
        //product.where(x => x.id > 5)
        //product.where(x => x.id > 5).OrderBy
        //product.where(x => x.id > 5).OrderBy(ada göre).ToListAsync();
        //reflection => <delegeler> methodları işaret eden yapılardır.
        //id si 5 ten büyük mü göster ve true == aktif olanlar gelsin
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        
    }
}
