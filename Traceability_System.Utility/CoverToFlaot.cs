using System.Text;

namespace Traceability_System.Utility;

public class CoverToFlaot
{

    public static string NewConvertToFloat(string str, int floatNum)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;


        //str = str.Trim();
        if (str.All(c => c == '0'))
        {
            return str.Replace('0', ' ');
        }


        if (str.Contains('+'))
        {
            str = str.Replace('+', ' ');
            //Console.WriteLine(str.Replace('+', ' '));
        }


        int length = str.Length;

        int startNum = length + floatNum;

        int endNum = length - startNum;
        StringBuilder resultBuilder = new StringBuilder(str);
        //小数点前
        string frontPart = resultBuilder.ToString(0, Math.Min(startNum, resultBuilder.Length));

        //小数点后
        string backPart = resultBuilder.ToString(Math.Max(0, resultBuilder.Length - endNum), endNum);

        // 移除整数部分的前导零
        string frontPartChar = frontPart.TrimStart('0').Trim();

        // 如果整数部分为空，则设置为 "0"
        if (string.IsNullOrEmpty(frontPartChar) || frontPartChar == "00")
        {
            frontPartChar = "0";
        }
        else if (frontPartChar == "-")
        {
            frontPartChar += '0';
        }
        else if (frontPartChar == "-00")
        {
            frontPartChar = "-0";
        }


        // 处理小数部分
        string decimalPart = backPart.TrimEnd('0').Trim();


        // 重新组合整数和小数部分
        resultBuilder.Clear();
        resultBuilder.Append(frontPartChar);

        if (!string.IsNullOrEmpty(decimalPart))
        {
            resultBuilder.Append('.').Append(decimalPart);
        }

        return resultBuilder.ToString();
    }
}