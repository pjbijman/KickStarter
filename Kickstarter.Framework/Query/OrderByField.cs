using System;
using System.Linq.Expressions;

namespace KickStarter.Framework.Query
{
    public class OrderByField
    {
        public OrderByField(string propertyName, bool isAscending)
        {
            PropertyName = propertyName;
            IsAscending = isAscending;
        }

        public OrderByField(LambdaExpression propertyExpression, bool isAscending)
        {
            PropertyExpression = propertyExpression;
            IsAscending = isAscending;
        }

        public string PropertyName { get; set; }
        public LambdaExpression PropertyExpression { get; set; }
        public bool IsAscending { get; set; }
    }

    public class OrderByField<T, TKey> : OrderByField where T : class
    {
        public OrderByField(Expression<Func<T, TKey>> keySelector, bool isAscending)
            : base(keySelector, isAscending)
        {
            KeySelector = keySelector;
        }

        public Expression<Func<T, TKey>> KeySelector { get; set; }
    }
}