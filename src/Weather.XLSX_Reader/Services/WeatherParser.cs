using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Asn1.Crmf;
using System.IO;
using Weather.Services.Models;
using Weather.Services.Services;

namespace Weather.XLSX_Reader.Services;

public class WeatherParser : IWeatherParser
{
    public IEnumerable<WeatherData> Parse(Stream stream)
    {
        List<WeatherData> data = new List<WeatherData>();
        XSSFWorkbook workbook;
        ISheet sheet;
        try
        {
            workbook = new XSSFWorkbook(stream);
            sheet = workbook.GetSheetAt(0);
        }
        catch
        {
            throw new InvalidOperationException("Incorrect file");
        }
        int i = 4;
        IRow row = sheet.GetRow(i);
        if (row is null)
        {
            throw new InvalidOperationException("Incorrect file");
        }
        while (row is not null)
        {
            data.Add(CreateWeatherData(row));
            i++;
            row = sheet.GetRow(i);
        }

        return data;
    }

    private WeatherData CreateWeatherData(IRow row)
    {
        int i = 0;
        try
        {
            var date = DateOnly.ParseExact(GetCell(row, ref i).StringCellValue, "dd.MM.yyyy");
            var time = TimeOnly.Parse(GetCell(row, ref i).StringCellValue);
            var temp = (float)GetCell(row, ref i).NumericCellValue;
            var relativeHumidity = (int)GetCell(row, ref i).NumericCellValue;
            var dewPoint = (float)GetCell(row, ref i).NumericCellValue;
            var atmospherePressure = (int)GetCell(row, ref i).NumericCellValue;
            var windDirection = GetCell(row, ref i).StringCellValue;
            int? windSpeed = ParseIntCell(GetCell(row, ref i));
            int? cloudiness = ParseIntCell(GetCell(row, ref i));
            int? cloudBase = ParseIntCell(GetCell(row, ref i));
            int? horizontalVisibility = ParseIntCell(GetCell(row, ref i));
            var weatherConditionsCell = GetCell(row, ref i);
            var weatherConditions = weatherConditionsCell is null ? null : weatherConditionsCell.StringCellValue;
            return new WeatherData(date, time, temp, relativeHumidity, dewPoint, atmospherePressure, windDirection, windSpeed, cloudiness, cloudBase, horizontalVisibility, weatherConditions);
        }
        catch (Exception ex)
        {
            var cell = row.GetCell(i - 1);
            if (cell is null)
            {
                throw;
            }
            throw new InvalidOperationException($"Incorrect data at cell: {cell.Address}", ex);
        }
    }

    private ICell GetCell(IRow row, ref int cellIndex)
    {
        var cell = row.GetCell(cellIndex);
        cellIndex++;
        return cell;
    }

    private int? ParseIntCell(ICell cell)
    {
        try
        {
            return (int)cell.NumericCellValue;
        }
        catch
        {
            var stringValue = cell.StringCellValue;
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }
            throw new InvalidOperationException();
        }
    }

}
