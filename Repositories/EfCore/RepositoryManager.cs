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
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IMainCategoryRepository> _mainCategoryRepository;
        private readonly Lazy<ISubCategoryRepository> _subCategoryRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _mainCategoryRepository = new Lazy<IMainCategoryRepository>(() => new MainCategoryRepository(_context));
            _subCategoryRepository = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(_context));   
        }
        /* 
    * Ürünler üzerinde işlemler yapmak için IProductRepository arayüzünü sağlar.
    * Ürün deposunu tembel yükleme ile sağlar, böylece gerektiğinde yüklenir.
    */
        public IProductRepository Product => _productRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public IMainCategoryRepository MainCategory => _mainCategoryRepository.Value;

        public ISubCategoryRepository SubCategory => _subCategoryRepository.Value;

        /* 
* Yapılan değişiklikleri veritabanına kaydeder.
* Kaydetme işlemi, bağlam nesnesinin SaveChanges metodu ile gerçekleştirilir.
*/
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            
        }
    }
}
