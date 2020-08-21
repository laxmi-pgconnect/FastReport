using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FastReportSimpleExample.Models;

namespace FastReportSimpleExample
{
    public static class Services
    {
        public static DataSet ConvertToDataSet<T>(this IEnumerable<T> source, string name)
        {
            if (source == null)
                throw new ArgumentNullException("source ");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            var converted = new DataSet(name);
            converted.Tables.Add(NewTable(name, source));
            return converted;
        }

        private static DataTable NewTable<T>(string name, IEnumerable<T> list)
        {
            PropertyInfo[] propInfo = typeof(T).GetProperties();
            DataTable table = Table<T>(name, list, propInfo);
            IEnumerator<T> enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
                table.Rows.Add(CreateRow<T>(table.NewRow(), enumerator.Current, propInfo));
            return table;
        }

        private static DataRow CreateRow<T>(DataRow row, T listItem, PropertyInfo[] pi)
        {
            foreach (PropertyInfo p in pi)
                row[p.Name.ToString()] = p.GetValue(listItem, null);
            return row;
        }

        private static DataTable Table<T>(string name, IEnumerable<T> list, PropertyInfo[] pi)
        {
            DataTable table = new DataTable(name);
            foreach (PropertyInfo p in pi)
                table.Columns.Add(p.Name, p.PropertyType);
            return table;
        }

        public static List<tm_itemtype> GetItemtype()
        {
            List<tm_itemtype> ItemtypeList = new List<tm_itemtype>();
            var myItem = new tm_itemtype() { ItemType = "CH", Descn = "CHILLED CHICKEN", IsActive = "A",Nature="R" };
            ItemtypeList.Add(myItem);
            myItem = new tm_itemtype() { ItemType = "FC", Descn = "FROZEN CHICKEN", IsActive = "A", Nature = "R" };
            ItemtypeList.Add(myItem);
            myItem = new tm_itemtype() { ItemType = "SW", Descn = "SCRAP AND WASTE", IsActive = "A", Nature = "R" };
            ItemtypeList.Add(myItem);
            myItem = new tm_itemtype() { ItemType = "FD", Descn = "FEED", IsActive = "A", Nature = "R" };
            ItemtypeList.Add(myItem);
            return ItemtypeList;
        }

    }
}
