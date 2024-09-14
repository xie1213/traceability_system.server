using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.Models.ExportedMethod
{
    public class MergeExcel
    {
       public static void MergeExcelFiles(string filePath1, string filePath2)
        {
            string outputFilePath = @"D:\WindowsTools\Desktop\合并结果.xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                // 加载工作簿
                using (var package1 = new ExcelPackage(new FileInfo(filePath1)))
                using (var package2 = new ExcelPackage(new FileInfo(filePath2)))
                using (var outputPackage = new ExcelPackage())
                {
                    // 获取第一个工作表
                    var worksheet1 = package1.Workbook.Worksheets[0];
                    var worksheet2 = package2.Workbook.Worksheets[0];
                    
                    // 创建一个新的工作表用于合并
                    var outputWorksheet = outputPackage.Workbook.Worksheets.Add("Merged");

                    // 复制第一个工作表的内容到新的工作表
                    var rowCount1 = worksheet1.Dimension.End.Row;
                    var colCount1 = worksheet1.Dimension.End.Column;
                    for (int row = 1; row <= rowCount1; row++)
                    {
                        for (int col = 1; col <= colCount1; col++)
                        {
                            outputWorksheet.Cells[row, col].Value = worksheet1.Cells[row, col].Value;
                        }
                    }


                    // 复制第二个工作表的内容到新的工作表
                    var rowCount2 = worksheet2.Dimension.End.Row;
                    var colCount2 = worksheet2.Dimension.End.Column;
                    int startRow = rowCount1 + 1;
                    for (int row = 1; row <= rowCount2; row++)
                    {
                        for (int col = 1; col <= colCount2; col++)
                        {
                            outputWorksheet.Cells[startRow + row - 1, col].Value = worksheet2.Cells[row, col].Value;
                        }
                    }
                    outputWorksheet.Cells[outputWorksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽
                                                                                               // 保存合并后的文件
                    outputPackage.SaveAs(new FileInfo(outputFilePath));
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

    }
}
