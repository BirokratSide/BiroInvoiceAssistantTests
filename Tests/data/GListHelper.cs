using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Tests.data.structs;

namespace Tests.data
{
    public static class GListHelper
    {
        public static SListResponse<T> ListResponse<T>(DataTable data, SListRequest request, bool include_underscores = false) where T : new()
        {
            SListResponse<T> lst = new SListResponse<T>();

            if (data.Rows.Count == 0)
            {
                lst.data = new List<T>();
                return lst;
            }

            lst.items_total = data.Rows.Count;
            DataTable dttOut = null;
            
            lst.items_per_page = lst.items_total;
            lst.page_count = 1;
            lst.page_current = 1;
            dttOut = data;

            lst.item_count = dttOut.Rows.Count;
            lst.data = new List<T>();
            foreach (DataRow dr in dttOut.Rows)
            {
                T item = new T();
                GDataTypeConverter.ObjectFromDataRow(item, dr, include_underscores);
                lst.data.Add(item);
                item = default(T);
            }
            return lst;
        }
        public static SListResponse<T> ListResponse<T>(DataSet data, SListRequest request, bool include_underscores = false) where T : new()
        {
            SListResponse<T> lst = new SListResponse<T>();

            if (data.Tables[1].Rows.Count == 0)
            {
                lst.data = new List<T>();
                return lst;
            }
            lst.item_count = data.Tables[1].Rows.Count;
            lst.items_per_page = request.items_per_page;
            lst.items_total = int.Parse(data.Tables[0].Rows[0][0].ToString());
            lst.page_current = request.current_page;
            lst.page_count = (int)Math.Ceiling((double)lst.items_total / lst.items_per_page);
            lst.success = true;
            lst.data = new List<T>();
            foreach (DataRow dr in data.Tables[1].Rows)
            {
                T item = new T();
                GDataTypeConverter.ObjectFromDataRow(item, dr, include_underscores);
                lst.data.Add(item);
                item = default(T);
            }
            return lst;
        }
        
    }
}