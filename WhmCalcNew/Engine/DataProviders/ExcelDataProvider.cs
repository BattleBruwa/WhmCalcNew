using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.ObjectModel;
using System.IO;
using WhmCalcNew.Models;


namespace WhmCalcNew.Engine.DataProviders
{
    // Больше не используется
    [Obsolete]
    public class ExcelDataProvider
    {
        // Путь до таблицы юнитов:
        private static string _dataPath { get { return string.Concat($"{Path.GetFullPath("../../../Data")}", "\\UnitStats.xlsx"); } }

        public static void FillTargetCollection(ObservableCollection<TargetUnit> collectionToFill)
        {
            using (SpreadsheetDocument xlDoc = SpreadsheetDocument.Open(_dataPath, false))
            {
                Sheet xlSheet = xlDoc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                Worksheet xlWorksheet = (xlDoc.WorkbookPart.GetPartById(xlSheet.Id.Value) as WorksheetPart)!.Worksheet;

                // Получить строки в листе:
                IEnumerable<Row> rows = xlWorksheet.GetFirstChild<SheetData>().Descendants<Row>();

                foreach (Row row in rows)
                {
                    // Не обрабатывать первую строку, тк она
                    // является заголовком
                    if (row.RowIndex.Value != 1)
                    {
                        string tgFaction = GetCellValue(xlDoc, (Cell)row.ElementAt(0));

                        string tgName = GetCellValue(xlDoc, (Cell)row.ElementAt(1));

                        byte tgTougness = byte.Parse(GetCellValue(xlDoc, (Cell)row.ElementAt(2)));

                        byte tgSave = byte.Parse(GetCellValue(xlDoc, (Cell)row.ElementAt(3)));

                        byte tgWounds = byte.Parse(GetCellValue(xlDoc, (Cell)row.ElementAt(4)));

                        byte? tgInvuln = byte.Parse(GetCellValue(xlDoc, (Cell)row.ElementAt(5)));

                        collectionToFill.Add(new TargetUnit() { UnitName = tgName, Toughness = tgTougness, Save = tgSave, Wounds = tgWounds});
                    }
                }
            }
        }

        // Вспомогательный метод для получения значений в клетке таблицы
        private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            if (cell.CellValue != null)
            {
                string value = cell.CellValue.InnerText;

                // Значение свойства DataType равно NULL для числовых типов и дат
                // и CellValues.SharedString для строк:
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return document.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.ElementAt(int.Parse(value)).InnerText;
                }
                else
                {
                    return value;
                }
            }
            return string.Empty;
        }
    }
}
