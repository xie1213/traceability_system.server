using Microsoft.Data.SqlClient.Server;
using System.Globalization;

namespace Traceability_System.Utility;

public class CoverToTime
{
    /// <summary>
    /// 格式转换字典
    /// key为输入字符串长度,value为对应的解析格式和输出格式
    /// </summary>
    private static readonly Dictionary<int, (string OldFormat, string NewFormat)> Formats = new()
    {
        [3] = ("yyMM", "yy-MM"),
        [5] = ("yyMMdd", "yy-MM-dd"),
        [6] = ("yyMMdd", "yy-MM-dd"),
        [8] = ("yyyyMMdd", "yyyy-MM-dd"),
        [12] = ("yyMMddHHmmss", "yy-MM-dd HH:mm:ss")
    };
    public static string ConvertToTime(string input)
    {
        //string format;

        if (string.IsNullOrWhiteSpace(input))
            return input;

        if (input.All(c => c == '0'))
        {
            
            return input.Replace('0', ' ');
        }
        try
        {
            //循环输出字典
            if (DateTime.TryParseExact(input, "yyMMddHHmmss", null, DateTimeStyles.None, out var dt))
            {
                return dt.ToString("yy-MM-dd HH:mm:ss");
            }
        }catch (FormatException e)
        {
            throw e;
        }
        return input;

    }
    
}