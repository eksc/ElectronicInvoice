using ElectronicInvoice.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicInvoice.Infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IEnumerable<TEntity> GetCollection(IEnumerable<TEntity> inputCollection,
            ISpecification<TEntity> specification)
        {
            var collection = inputCollection;

            if (specification.Criteria != null)
            {
                collection = collection.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                collection = collection.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                collection = collection.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                collection = collection.Skip(specification.Skip)
                                       .Take(specification.Take);
            }

            return collection;
        }
    }
}
