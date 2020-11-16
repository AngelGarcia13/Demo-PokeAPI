﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeAPI.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex < TotalPages); }
        }

        public static PaginatedList<T> Create(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();//With EF .CountAsync()
            var items = source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();//With EF .ToListAsync()
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
