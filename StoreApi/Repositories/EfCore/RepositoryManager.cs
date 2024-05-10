using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    /* 
         * RepositoryManager sınıfı, veritabanı işlemlerini yönetmek için kullanılır. 
         * Özellikle, IProductRepository arayüzünü kullanarak ürünler üzerinde işlemler yapar.
         */
    public class RepositoryManager : IRepositoryManager
    {
        // private readonly RepositoryContext _context; // Veritabanı işlemleri için bağlam nesnesini tutar.
        // private readonly Lazy<IProductRepository> _productRepository; // Ürünler üzerinde işlemler yapmak için ürün deposunu temsil eden tembel yükleme nesnesini tutar.

        private readonly RepositoryContext _context;
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
        }
        /* 
    * Ürünler üzerinde işlemler yapmak için IProductRepository arayüzünü sağlar.
    * Ürün deposunu tembel yükleme ile sağlar, böylece gerektiğinde yüklenir.
    */
        public IProductRepository Product => _productRepository.Value;
        /* 
   * Yapılan değişiklikleri veritabanına kaydeder.
   * Kaydetme işlemi, bağlam nesnesinin SaveChanges metodu ile gerçekleştirilir.
   */
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
