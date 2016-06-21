using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridViewHelper
{
    /// <summary>
    /// 拓展方法，目标为IQueryable对象添加表数据显示的拓展方法
    /// </summary>
    public static class TableDataPageLinqExtensions
    {
        public static TableDataPagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize, string identityColumnName, string sortExpression)
        {
            var truePageIndex = pageIndex ?? 0;
            var itemIndex = truePageIndex * pageSize;
            var pageOfItems= allItems.Skip(itemIndex).Take(pageSize);

            return new TableDataPagedList<T>(pageOfItems,truePageIndex,pageSize,allItems.Count(),identityColumnName,sortExpression);
        }

        public static TableDataPagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize,string identityColumnName)
        {
            return ToPagedList(allItems, pageIndex, pageSize, identityColumnName,string.Empty);
        }

         public static TableDataPagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize)
        {
            return ToPagedList(allItems, pageIndex, pageSize, null,string.Empty);
        }
    }
}
