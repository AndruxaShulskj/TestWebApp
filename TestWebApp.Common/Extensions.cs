using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Common
{
    public static class Extensions
    {
        public static IQueryable<T> UseCustomFilter<T>(this DbSet<T> dbSet, DataFilter? filter) where T : class
        {
            var query = dbSet.AsQueryable();
            if (filter is null) return query;

            var properties = typeof(T).GetProperties().ToList();
            var property = properties.FirstOrDefault(p => string.Equals(p.Name, filter.PropertyName, StringComparison.CurrentCultureIgnoreCase)) ?? throw new Exception($"Property with name {filter.PropertyName} doesn't exist");
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, property.Name);
            var value = Convert.ChangeType(filter.Value, property.PropertyType);

            query = filter.DataFilterType switch
            {
                DataFilterType.Equals => query.Where(
                    Expression.Lambda<Func<T, bool>>(Expression.Equal(member, Expression.Constant(value)),
                        parameter)),
                DataFilterType.NotEquals => query.Where(
                    Expression.Lambda<Func<T, bool>>(Expression.NotEqual(member, Expression.Constant(value)),
                        parameter)),
                _ => throw new Exception("Type of filter does not exist")
            };
            return query;
        }

    }
}
