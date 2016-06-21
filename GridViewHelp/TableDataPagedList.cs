using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridViewHelper
{
    /// <summary>
    /// 考虑分页的数据源控制
    /// </summary>
    /// <typeparam name="T">显示的数据类型</typeparam>
    public  class TableDataPagedList<T>:List<T>
    {
        //当前显示数据的再数据源中的页码
        public int PageIndex { get; set; }
        //分页中每页数据的大小
        public int PageSize { get; set; }
        //数据源中数据的总记录数
        public int TotalItemCount { get; set; }
        //数据源中数据的总页数
        public int TotalPageCount { get; set; }
        //数据源中的主键列
        public string IdentityColumnName { get; set; }
        //排序的表达式
        public string SortExpression { get; set; }


        public TableDataPagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount, string identityColumnName, string sortExpression)
        {
            this.AddRange(items);
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalItemCount = totalItemCount;
            this.TotalPageCount = (TotalItemCount + PageSize - 1) / PageSize;
            this.IdentityColumnName = identityColumnName;
            this.SortExpression = sortExpression;

        }
    }
}
