namespace Logtracker.Helpers
{
    // Utility: merapikan konfigurasi kolom DataGridView. Null-safe — kalau kolom
    // tidak ada, perintah diabaikan diam-diam (menggantikan cek "!= null" berulang
    // yang sebelumnya ditulis ulang di tiap Form).
    public static class DataGridViewExtensions
    {
        public static void HideColumn(this DataGridView grid, string columnName)
        {
            if (grid.Columns[columnName] is DataGridViewColumn column)
                column.Visible = false;
        }

        public static void HideColumns(this DataGridView grid, params string[] columnNames)
        {
            foreach (var name in columnNames)
                grid.HideColumn(name);
        }

        public static void SetHeader(this DataGridView grid, string columnName, string headerText)
        {
            if (grid.Columns[columnName] is DataGridViewColumn column)
                column.HeaderText = headerText;
        }

        public static void SetDateFormat(this DataGridView grid, string columnName, string format)
        {
            if (grid.Columns[columnName] is DataGridViewColumn column)
                column.DefaultCellStyle.Format = format;
        }
    }
}
