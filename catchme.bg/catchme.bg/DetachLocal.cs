using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg
{
    public static class ExtensionMethods
    {
        public interface IIdentifier
        {
            int ID { get; set; }
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
                .FirstOrDefault(entry => entry.ID.Equals(entryId));
            if (!local.IsNull())
            {
                context.Entry(local).State = EntityState.Detached;
            }

            context.Entry(t).State = EntityState.Modified;
        }
    }
}
