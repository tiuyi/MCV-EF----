using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.Common
{
    public class SearchHelper
    {
        /// <summary>
        /// 动态解析搜索类查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="search_model"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> FilterWhere<T, V>(V search_model)
        {
            var whereLambda = PredicateBuilder.True<T>();
            Type t_model = typeof(T);
            Type t_search_model = search_model.GetType();
            System.Reflection.PropertyInfo[] s_properties = t_search_model.GetProperties();

            foreach (var s in s_properties)
            {
                if (s.CanRead && s.GetValue(search_model) != null)
                {
                    if (s.PropertyType.Name == "Nullable`1")
                    {
                        var TypeName = Nullable.GetUnderlyingType(s.PropertyType).Name;
                        if (TypeName == "Decimal" || TypeName == "Int32" || TypeName == "Double")
                        {
                            var attr = t_model.GetProperty(s.Name);
                            if (attr != null && attr.CanRead)
                            {
                                var value = s.GetValue(search_model);
                                whereLambda = CreateLambda<T>(whereLambda, s.Name, value, "=");
                            }
                        }
                        else if (TypeName == "DateTime")
                        {
                            if (s.Name.IndexOf("From") > -1)
                            {
                                var field = s.Name.Substring(4);
                                var attr = t_model.GetProperty(field);
                                if (attr != null && attr.CanRead)
                                {
                                    var value = Convert.ToDateTime(s.GetValue(search_model));
                                    whereLambda = CreateLambda<T>(whereLambda, field, value, ">=");
                                }
                            }
                            else if (s.Name.IndexOf("To") > -1)
                            {
                                var field = s.Name.Substring(2);
                                var attr = t_model.GetProperty(field);
                                if (attr != null && attr.CanRead)
                                {
                                    var value = Convert.ToDateTime(s.GetValue(search_model));
                                    whereLambda = CreateLambda<T>(whereLambda, field, value, "<=");
                                }
                            }
                            else
                            {
                                var attr = t_model.GetProperty(s.Name);
                                if (attr != null && attr.CanRead)
                                {
                                    var value = Convert.ToDateTime(s.GetValue(search_model));
                                    whereLambda = CreateLambda<T>(whereLambda, s.Name, value, "<=");
                                }
                            }
                        }
                    }
                    else if (s.PropertyType.Name == "String")
                    {
                        var attr = t_model.GetProperty(s.Name);
                        if (attr != null && attr.CanRead)
                        {
                            var value = s.GetValue(search_model).ToString();
                            whereLambda = CreateLambda<T>(whereLambda, s.Name, value, "like");
                        }
                    }
                }
            }
            return whereLambda;
        }

        /// <summary>
        /// 创建Lambda表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda">whereLambda表达式</param>
        /// <param name="field">字段</param>
        /// <param name="value">值</param>
        /// <param name="Operator">操作标识</param>
        /// <returns></returns>
        private static Expression<Func<T, bool>> CreateLambda<T>(Expression<Func<T, bool>> whereLambda, string field, object value, string Operator = "=")
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
            Type oldType = typeof(T).GetProperty(field).PropertyType;
            BinaryExpression query = null;
            switch (Operator)
            {
                case "=":
                    query = Expression.Equal(Expression.PropertyOrField(parameter, field), Expression.Constant(value, oldType));
                    break;
                case ">=":
                    query = Expression.GreaterThanOrEqual(Expression.PropertyOrField(parameter, field), Expression.Constant(value, oldType));
                    break;
                case "<=":
                    query = Expression.LessThanOrEqual(Expression.PropertyOrField(parameter, field), Expression.Constant(value, oldType));
                    break;
                case "like":
                    Expression filter = Expression.Call(Expression.PropertyOrField(parameter, field), typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), Expression.Constant(value, oldType));
                    //Expression filter = Expression.Call(typeof(T).GetMethod("like", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public), parameter, Expression.Constant(value));
                    return whereLambda.And(Expression.Lambda<Func<T, Boolean>>(filter, parameter));
            }
            return whereLambda.And(Expression.Lambda<Func<T, Boolean>>(query, parameter));
        }
    }


}
