using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace catchme.bg
{
    public static class ExtensionMethods
    {
        public interface IIdentifier
        {
            int Id { get; set; }
        }

        public static bool IsNull<T>(this T t)
        {
            return t == null;
        }

        public static void DetachLocal<T>(this DbContext context, T t, string entryId)
            where T : class, IIdentifier
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entryId));
            if (!local.IsNull())
            {
                context.Entry(local).State = EntityState.Detached;
            }

            context.Entry(t).State = EntityState.Modified;
        }

        //Warning: The following is only suitable for small tables (think < 1000 rows)
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
        
    }
}
