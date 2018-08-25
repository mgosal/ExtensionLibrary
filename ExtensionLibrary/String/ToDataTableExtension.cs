using System.Data;

namespace ExtensionLibrary
{
    public static class ToDataTableExtension
    {
        public static DataTable ToDataTable(this string @this)
        {
            var table = new DataTable();
            table.Columns.Add("String", typeof(string));
            var row = table.NewRow();
            row["String"] = @this;
            table.Rows.Add(row);
            return table;
        }
    }
}
