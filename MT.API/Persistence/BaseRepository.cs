using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace  AggriPortal.API.Persistence
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext context { get; set; }
        protected DbSet<T> DbSet { get; set; }
        public BaseRepository(AppDbContext _context)
        {
            this.context = _context;
            DbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await this.DbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this.DbSet.AddRangeAsync(entities);
        }
        public void UpdateAsync(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            this.DbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            this.DbSet.RemoveRange(entities);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await this.DbSet.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }
        public IQueryable<T> GetMany(Expression<Func<T, bool>> expression)
        {
                return this.DbSet.Where(expression).AsNoTracking().AsQueryable();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.DbSet.AsNoTracking().ToListAsync();
        }
        public IQueryable<T> Include(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeExpressions)
        {
            DbSet<T> dbSet = DbSet;

            //IQueryable<T> query = null;
            //foreach (var includeExpression in includeExpressions)
            //{
            //    query = dbSet.Include(includeExpression);
            //}

            //return query ?? dbSet;
            includeExpressions.ToList().ForEach(x => DbSet.Include(x).Load());
            return DbSet;
        }
        public async Task<IEnumerable<T>> ExcuteQuerys(string query, params object[] parameters)
        {
            return await DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }

        public async Task<dynamic> ExcuteQuery(string query, params object[] parameters)
        {
            return await DbSet.FromSqlRaw(query, parameters).FirstOrDefaultAsync();
        }
        public async Task<dynamic> ExcuteQueryList(string query, params object[] parameters)
        {
            return await DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }
        //private static IEnumerable<string> GetIncludePaths(this DbContext context, Type clrEntityType)
        //{
        //    var entityType = context.Model.FindEntityType(clrEntityType);
        //    var includedNavigations = new HashSet<INavigation>();
        //    var stack = new Stack<IEnumerator<INavigation>>();
        //    while (true)
        //    {
        //        var entityNavigations = new List<INavigation>();
        //        foreach (var navigation in entityType.GetNavigations())
        //        {
        //            if (includedNavigations.Add(navigation))
        //                entityNavigations.Add(navigation);
        //        }
        //        if (entityNavigations.Count == 0)
        //        {
        //            if (stack.Count > 0)
        //                yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
        //        }
        //        else
        //        {
        //            foreach (var navigation in entityNavigations)
        //            {
        //                var inverseNavigation = navigation.FindInverse();
        //                if (inverseNavigation != null)
        //                    includedNavigations.Add(inverseNavigation);
        //            }
        //            stack.Push(entityNavigations.GetEnumerator());
        //        }
        //        while (stack.Count > 0 && !stack.Peek().MoveNext())
        //            stack.Pop();
        //        if (stack.Count == 0) break;
        //        entityType = stack.Peek().Current.GetTargetType();
        //    }
        //}
    }
}
