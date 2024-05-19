using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System.Data;

namespace equipment_accounting_system.Classes
{
    internal class file_Export
    {

        public void ExportToExcel(DataGridView dgv, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Logs");
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        var cellValue = dgv.Rows[i].Cells[j].Value;

                        if (cellValue != null)
                        {
                            if (cellValue is int)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = (int)cellValue;
                            }
                            else if (cellValue is double || cellValue is float || cellValue is decimal)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = Convert.ToDouble(cellValue);
                            }
                            else
                            {
                                worksheet.Cell(i + 2, j + 1).Value = cellValue.ToString();
                            }
                        }
                    }
                }

                workbook.SaveAs(filePath);
            }
        }

        public void ExportToPdf(DataGridView dgv, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                    }
                }
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
            }
        }

        public void ExportToJson(DataGridView dgv, string filePath)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value?.ToString() ?? string.Empty;
                }
                dt.Rows.Add(dr);
            }

            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void ExportToCsv(DataGridView dgv, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    writer.Write(dgv.Columns[i].HeaderText);
                    if (i < dgv.Columns.Count - 1)
                    {
                        writer.Write(",");
                    }
                }
                writer.WriteLine();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        writer.Write(row.Cells[i].Value?.ToString());
                        if (i < dgv.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }







    }
}
