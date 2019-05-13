using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Suckless.Asserts
{
    internal static class MetadataFactory 
    {
        public static Metadata<TValue> MetadataFrom<TValue>(Expression<Func<TValue>> expression)
        {
            if (!(expression.Body is MemberExpression)) throw ApplicationException();
            var memberExpression = (MemberExpression)expression.Body;

            var name = memberExpression.Member.Name;

            if (memberExpression.Expression is ConstantExpression)
            {
                var value = (TValue)SelectValue(ref memberExpression, 
                    ((ConstantExpression)memberExpression.Expression).Value);
                return new Metadata<TValue>(value, name);
            }

            var nestedMemberExpression = (MemberExpression)memberExpression.Expression;
            if (nestedMemberExpression == null) throw ApplicationException();

            if (!(nestedMemberExpression.Expression is ConstantExpression)) throw ApplicationException();
            var obj = SelectValue(ref nestedMemberExpression, 
                ((ConstantExpression)nestedMemberExpression.Expression).Value);

            return new Metadata<TValue>((TValue)SelectValue(ref memberExpression, obj), name);
        }

        private static object SelectValue(ref MemberExpression memberExpression, object obj)
        {
            return memberExpression.Member is FieldInfo
                ? ((FieldInfo)memberExpression.Member).GetValue(obj)
                : ((PropertyInfo)memberExpression.Member).GetValue(obj);
        }

        private static ApplicationException ApplicationException() => new ApplicationException(
                    "You can use only nonstatic property or field and the first level nested variable like AnyClass.Property.");
    }
}
