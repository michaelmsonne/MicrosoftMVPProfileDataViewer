using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MVPProfileDataViewer.Class
{
    internal class ContextExporter
    {
        public void ExportToCsv(DataGridView dataGridView, string filePath)
        {
            var csv = new StringBuilder();

            // Add header row
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                csv.Append(EscapeCsvValue(dataGridView.Columns[i].HeaderText));
                if (i < dataGridView.Columns.Count - 1)
                    csv.Append(",");
            }
            csv.AppendLine();

            // Add data rows
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        csv.Append(EscapeCsvValue(row.Cells[i].Value?.ToString()));
                        if (i < dataGridView.Columns.Count - 1)
                            csv.Append(",");
                    }
                    csv.AppendLine();
                }
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        private string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }
    }
}