using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomMoodle.Models
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => (PageIndex > 1);

        public bool HasNextPage => (PageIndex < TotalPages);

        public static async Task<List<T>> InstallPaging(IQueryable<T> source, int pageIndex, int pageSize)
        {
            return await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items =await InstallPaging(source, pageIndex, pageSize);
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
        public static PagedList<T> Create(List<T> source, int totalCount, int pageIndex, int pageSize)
        {
            return new PagedList<T>(source, totalCount, pageIndex, pageSize);
        }
    }
}