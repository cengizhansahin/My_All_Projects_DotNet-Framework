using BlogApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogContext _context;

        public EfRepository(BlogContext context)
        {
            _context = context;
        }

        IQueryable<T> IRepository<T>.List => _context.Set<T>();

        public async Task Create(T p)
        {
            _context.Set<T>().Add(p);
            await _context.SaveChangesAsync();
        }
    }
}
