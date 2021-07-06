using System.Windows.Forms;

namespace Steam_Server_Browser.Utils
{
    public class GetCellValue
    {
        public string GetCell(DataGridView dt,int Row, int Cell)
        {
            return dt.Rows[Row].Cells[Cell].Value.ToString();
        }
    }
}
