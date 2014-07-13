using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;
using MvcContrib.Pagination;
using MvcContrib.UI.Grid;
using MvcContrib.Sorting;


namespace Kino.Web.Models
{
    public static class IQueryableExtensions
    {
        public static SelectList ToSelectList<T>(this IQueryable<T> query, string dataValueField, string dataTextField, object selectedValue)
        {
            return new SelectList(query, dataValueField, dataTextField, selectedValue ?? -1);
        }

    }

    public class PagedViewModel<T>
    {

        public ViewDataDictionary ViewData { get; set; }
        public IQueryable<T> Query { get; set; }
        public GridSortOptions GridSortOptions { get; set; }
        public string DefaultSortColumn { get; set; }
        public IPagination<T> PagedList { get; private set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public int FirstPageNumber { get; set; }
        public int LastPageNumber { get; set; }

        public int PreviousPageNumber { get; set; }
        public int CurrentPageNumber { get; set; }
        public int NextPageNumber { get; set; }

        public PagedViewModel<T> AddFilter(Expression<Func<T, bool>> predicate)
        {
            Query = Query.Where(predicate);
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue>(string key, TValue value, Expression<Func<T, bool>> predicate)
        {
            ProcessQuery(value, predicate);
            ViewData[key] = value;
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue>(string keyField, object value, Expression<Func<T, bool>> predicate,
            IQueryable<TValue> query, string textField)
        {
            ProcessQuery(value, predicate);
            var selectList = query.ToSelectList(keyField, textField, value);
            ViewData[keyField] = selectList;
            return this;
        }

        public PagedViewModel<T> Setup()
        {
            if (GridSortOptions == null)
            {
                GridSortOptions = new GridSortOptions();
                GridSortOptions.Column = DefaultSortColumn;
            }

            PagedList = Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction)
                .AsPagination(Page ?? 1, PageSize ?? 10);

            if (PageSize.HasValue)
            {
                if ((Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) % PageSize.Value == 0)
                {
                    LastPageNumber = (Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) / PageSize.Value;
                }
                else
                {
                    LastPageNumber = ((Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) / PageSize.Value) + 1;
                }
            }
            else
            {
                if ((Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) % 10 == 0)
                {
                    LastPageNumber = (Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) / 10;
                }
                else
                {
                    LastPageNumber = ((Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).Count()) / 10) + 1;
                }
            }
            FirstPageNumber = 1;

            PreviousPageNumber = CurrentPageNumber - 1;
            NextPageNumber = CurrentPageNumber + 1;


            return this;
        }

        private void ProcessQuery<TValue>(TValue value, Expression<Func<T, bool>> predicate)
        {
            if (value == null) return;
            if (typeof(TValue) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value as string)) return;
            }

            Query = Query.Where(predicate);
        }
    }

}
