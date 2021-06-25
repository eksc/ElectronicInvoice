using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicInvoice.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Func<T, bool> criteria)
        {
            Criteria = criteria;
        }

        public Func<T, bool> Criteria { get; }

        public Func<T, object> OrderBy { get; private set; }

        public Func<T, object> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddOrderBy(Func<T, object> orderBy)
        {
            OrderBy = orderBy;
        }

        protected void AddOrderByDescending(Func<T, object> orderByDesc)
        {
            OrderByDescending = orderByDesc;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}
