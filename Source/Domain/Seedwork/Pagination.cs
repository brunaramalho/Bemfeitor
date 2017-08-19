﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Domain.Seedwork {

    public class Pagination<T> : IPagination<T> {

        #region Privates

        private readonly IEnumerable<T> _data;

        #endregion

        #region Properties

        public int PageSize { get; private set; }

        public int CurrentPage { get; private set; }

        public int Items { get; private set; }

        public int Pages {
            get {
                int result = (int)Math.Ceiling(((double)Items) / PageSize);
                return result == 0 ? 1 : result;
            }
        }

        public int First {
            get {
                return ((CurrentPage - 1) * PageSize) + 1;
            }
        }

        public int Last {
            get {
                return First + _data.Count() - 1;
            }
        }

        public bool HasPreviousPage {
            get { return CurrentPage > 1; }
        }

        public bool HasNextPage {
            get { return CurrentPage < Pages; }
        }

        #endregion

        #region Constructor

        public Pagination(IEnumerable<T> data, int currentPage, int pageSize, int items) {

            this.Items = items;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;

            this._data = data;
        }

        #endregion

        #region Methods

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            foreach (var item in _data) {
                yield return item;
            }
        }

        public IEnumerator GetEnumerator() {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        #endregion
    }
}
