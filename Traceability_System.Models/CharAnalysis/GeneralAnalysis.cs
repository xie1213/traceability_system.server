using Traceability_System.DTO;
using Traceability_System.Models.FileOperation;
using Traceability_System.Utility;

public class GeneralAnalysis : KeyList
{

    public string InputText { get; set; }
    public int LastIndex { get; set; } = 6;
    public List<List<string>> SubStrList = new();

    public virtual List<string> SplitList()
    {
        Basic();
        CaseAndHsgSerial();

        OneProcessHistory();
        AddTwelveToTime(2);

        var result = SubStrList.SelectMany(x => x).ToList();

        return result;

    }
    //基本信息
    public void Basic()
    {
        ListErgodic(BasicList, 7);

    }

    public void CaseAndHsgSerial()
    {
        //case And Hsg 序列
        for (int i = 1; i <= 2; i++)
        {
            SplitByIndex(15);
            LastIndex += 1;
        }
        //定子 -- 转子序列
        for (int i = 1; i <= 4; i++)
        {
            SplitByIndex(16);
        }
        //计数器驱动器 -- 差速器箱序列
        for (int i = 1; i <= 6; i++)
        {
            SplitByIndex(13);
            LastIndex += 3;
        }
        //Rr盖序列
        SplitByIndex(15);
        LastIndex += 1;

        //出货序列
        SplitByIndex(17);

        //Rr油泵序列
        SplitByIndex(13);
        LastIndex += 2;
    }

    //循环输出字符
    public void ListErgodic(List<(int, int)> strList, int skipItem = 0)
    {

        foreach (var (strLen, take) in strList)
        {
            SplitByIndex(strLen, take);
        }
        if (skipItem > 0)
        {
            LastIndex += skipItem;
        }
        //Console.WriteLine($"\r---------------{LastIndex},跳{skipItem}");
        //strList.Clear();
    }

    //获取字符串
    public void SplitByIndex(int strLen, int takeSize = 0, int skipSize = 0, string param = "")
    {
        if (LastIndex < 0 || LastIndex >= InputText.Length || strLen <= 0 || LastIndex + strLen > InputText.Length)
        {
            Logger.WriteLogAsync("无效参数或超出索引范围");

            return;
        }
        List<string> result;
        string substring = InputText.Substring(LastIndex, strLen) + param;

        // 转换时间
        if (takeSize > strLen)
        {
            takeSize = 0;
            substring = CoverToTime.ConvertToTime(substring);
        }

        // 转换小数
        if (takeSize < 0)
        {
            int floatLength = takeSize;

            //substring = CoverToFlaot.ConvertToFloat(substring, floatLength);

            substring = CoverToFlaot.NewConvertToFloat(substring, floatLength);
            takeSize = 0;
        }

        // 返回原始长度或按指定大小拆分
        result = takeSize == 0
            ? new List<string> { substring }
            : SplitString(substring, takeSize);

        SubStrList.Add(result);
        LastIndex += strLen + (skipSize != 0 ? skipSize : 0);
        //Console.WriteLine($"索引从{LastIndex - strLen}开始 - 到{LastIndex}结束");
    }

    private List<string> SplitString(string input, int chunkSize)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < input.Length; i += chunkSize)
        {
            string chunk = input.Substring(i, Math.Min(chunkSize, input.Length - i));
            result.Add(chunk);
        }
        return result;
    }

    //工程履历取一个字符
    public void OneProcessHistory()
    {
        TakeItem(OneList);
    }

    //工程履历
    public void TakeItem(List<(int, int)>? strList = null)
    {
        foreach (var (strLen, skipLen) in strList)
        {
            SplitByIndex(strLen, 1);
            LastIndex += skipLen;
            //Console.WriteLine($"\r---------------{LastIndex},跳{skipLen}");
        }

    }

    //防错时间
    public void TwelveToTime(int skipItem = 0)
    {
        ListErgodic(PokayDate, skipItem);
    }


    //hsgBrg压入
    public void HsgBrgPress()
    {
        TwelveToTime();
        ListErgodic(HsgBrgList, 1);
        //ListErgodic(HsgBrgList);
    }

    //向元组添加(5,-2) (4,0)
    public void AddFiveOrFourList(int countLen, int skipNum = 0)
    {
        FiveFourList = new List<(int, int)>();
        for (int i = 0; i < countLen; i++)
        {
            FiveFourList.Add((5, -2));
            FiveFourList.Add((4, 0));
        }
        ListErgodic(FiveFourList);
        FiveFourList.Clear();
    }

    //向元组中添加小数点后两位
    public void AddFive(int num, List<(int, int)> numList, int smallNum = -2)
    {
        for (int i = 0; i < num; i++)
        {
            numList.Add((5, smallNum));
        }
    }

    //向元组中添加(6,-2)
    public void AddSix(int num, List<(int, int)> numList)
    {
        for (int i = 0; i < num; i++)
        {
            numList.Add((6, -2));
        }
    }

    //MG磁化
    public void AddThreeFourOne(int num, int skipItem = 0)
    {
        var tempList = new List<(int, int)>();
        for (int i = 0; i < num; i++)
        {
            tempList.Add((3, -1));       //MG工件温度
            tempList.Add((4, -2));       //MG通量值
            tempList.Add((1, 0));        //MG判定
        }
        ListErgodic(tempList, skipItem);
    }

    /// <summary>
    /// 添加一个元素
    /// </summary>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="num"></param>
    /// <param name="skipNum"></param>
    public void AddOneItem(int item = 1, int num = 0)
    {
        //SplitByIndex(item, num, skipNum);

        SplitByIndex(item, num);
    }

    /// <summary>
    /// 添加两个元素
    /// </summary>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="num"></param>
    public void AddTwoItem(int count, int item, int num)
    {

        RepeatAction(count, _ =>
        {
            AddToList(1, item, num);
            AddOneItem();
        });
    }




    /// <summary>
    /// 添加时间
    /// </summary>
    /// <param name="num"></param>
    public void AddTwelveToTime(int numCount = 1)
    {
        AddToList(numCount, 12, 13);
    }


    public void AddThree(int count, int item, int num)
    {
        RepeatAction(count, _ =>
        {
            AddToList(1, 3, -2);
            AddToList(1, 4, -2);
            AddOneItem();
        });
    }

    public void AddFiveItem(int numCount, int num)
    {
        AddToList(numCount, 5, num);
    }

    /// <summary>
    /// 向List中添加数据
    /// </summary>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="num"></param>
    /// <param name="indexNum"></param>
    public void AddToList(int count = 1, int item = 1, int num = 0, int skipNum = 0)
    {
        if (count == 1)
        {
            SplitByIndex(item, num);
        }
        else
        {
            var list = new List<(int, int)>();
            RepeatAction(count, _ => list.Add((item, num)));
            ListErgodic(list, skipNum);
            list.Clear();
        }
    }

    /// <summary>
    /// 循环执行方法
    /// </summary>
    /// <param name="count">次数</param>
    /// <param name="action">方法</param>
    public void RepeatAction(int count, Action<int> action)
    {
        for (int i = 0; i < count; i++)
        {
            action(i);
        }
    }
}