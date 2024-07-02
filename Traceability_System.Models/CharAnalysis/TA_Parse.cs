namespace Traceability_System.Models.CharAnalysis;

public class TA_Parse : GeneralAnalysis
{
    public List<(int, int)> TaList;
    public TA_Parse(string txt)
    {
        InputText = txt;
    }
    public List<string> TA_SplitList()
    {
        base.SplitList();
        SimSelect();
        HsgPress();
        ThreeTime();
        HSG_Complex();
        OS_Press();
        //LeakTest
        //ISS_Date();
        var result = SubStrList.SelectMany(x => x).ToList();

        return result;
    }

    //シム選択
    public void SimSelect()
    {
        TaList = new List<(int, int)>();

        AddTwelveToTime(4);         //472 -- 519

        AddSixItem(8);              //520 -- 567

        //RepeatAction(4, i => TaList.Add((2, i == 3 ? 1 : 0))); // 568 -- 575

        //ListErgodic(TalList);
        AddToList(4, 2);

        AddToList(4, 4, -3);             //  576 -- 591

        AddOneItem();                                //  592

        AddFiveItem(4, -3);              //  593 -- 612

        AddSixItem(8);                           //  613 -- 661

        //AddOneItem();                                //  661
        LastIndex += 1;
    }

    //HSG压入
    void HsgPress()
    {
        RepeatAction(2, i =>        //662 -- 779 
        {
            AddTwelveToTime();
            AddFiveItem(9, -2);
            AddOneItem();
            LastIndex += 1;
        });
    }

    //防错防误20计测日時 -- HSG合体
    void ThreeTime()
    {
        AddTwelveToTime(2);    //780 -- 803
        AddOneItem(skipNum: 1);              //804
        //LastIndex += 1;            //805
        AddTwelveToTime();         //806--817
        LastIndex += 1;            //818
    }

    //HSG合体
    void HSG_Complex()
    {
        RepeatAction(2, _ =>     //819 -- 1044
        {
            TwelveToTime();
            AddFiveOrFourList(11);
            AddOneItem(skipNum: 1);
            //LastIndex += 1;                
        });


    }

    //OS压入
    void OS_Press()
    {
        AddTwelveToTime();              //1045 -- 1056

        RepeatAction(2, i => //1057 -- 1154
        {
            AddTwelveToTime();
            var numCount = i == 0 ? 9 : 5;
            AddFiveItem(numCount, -2);
            AddOneItem(skipNum: 1);
            //LastIndex += 1;             
        });

        AddTwelveToTime(6);         //1155 -- 1266

        LastIndex += 5;                 //1227 -- 1231
        LeakTest();
    }

    //泄漏测试
    void LeakTest()
    {
        TwelveToTime();         //1132--1243
        AddOneItem(7, -3);   //1244 -- 1250
        AddOneItem(6, -3);  //1251 -- 1256
        AddOneItem(4, -2);   //1257 -- 1260 

        AddOneItem(7, -3);  //1261 -- 1267
        AddOneItem(6, -3);  //1268 -- 1273
        LastIndex += 2;
        AddOneItem();           //1276
        AddOneItem(6, -3);  //1277 -- 1282
        LastIndex += 1;         //1283

        AddOneItem(3, -1);   //1284 -- 1286
        AddOneItem(3, -1);   //1287 -- 1289
        AddOneItem();           //1290

        AddTwoItem(6, 5, 0); //1291 -- 1326 


        AddOneItem();           //1237
        AddTwoItem(8, 5, -2);           //1238 -- 1375

        AddOneItem(5);           //1376 -- 1380
        AddOneItem(2);           //1381 -- 1382
        AddOneItem(3, 1);     //1383 -- 1385
        AddOneItem(5);           //1386 -- 1390
        AddTwoItem(6, 4, -2);//1391 -- 1420
        AddOneItem();


        LastIndex += 2;
        ISS_Date();
    }

    void ISS_Date()
    {
        TwelveToTime();         //1424 -- 1435
        AddOneItem(2, 1);     //1436 -- 1437
        LastIndex += 1;
        AddOneItem();           //1439
        AddTwoItem(4, 4, 0); //1440 -- 1459
        AddTwoItem(2, 5, -2); //1460 -- 1471
        AddTwoItem(4, 6, -4); //1472 -- 1499

        AddOneItem(4);          //1500 -- 1503
        AddOneItem(7, 1);    //1504 -- 1510
        AddTwoItem(2, 4, 0);//1511 -- 1520 
        AddOneItem(4, -2);          //1521 -- 1524
        AddThreeItem(20);  //1525 -- 1744
        LastIndex += 1;
        AddOneItem(2, 1);   //1746 -- 1747
        AddFiveItems(6);  //1748 -- 1855
        //AddToList(3);

        AddOneItem();           //1856
        LastIndex += 1;
        AddTwoItem(2, 3);//1858 -- 1865
        LastIndex += 6;
        AddTwelveToTime(9); //1872 -- 1979
        LastIndex += 4;
        AddOneItem(3);
        AddOneItem(5);
    }

    /// <summary>
    /// 添加一个元素
    /// </summary>
    /// <param name="item"></param>
    /// <param name="num"></param>
    /// <param name="skipNum"></param>
    void AddOneItem(int item = 1, int num = 0, int skipNum = 0, string param = "")
    {

        SplitByIndex(item, num, skipNum, param);
    }

    /// <summary>
    /// 6位数,3小数
    /// </summary>
    /// <param name="num"></param>
    void AddSixItem(int num)
    {
        AddToList(num, 6, -3);
    }

    //void AddFiveItem(int numCount, int num)
    //{
    //    AddToList(numCount, 5, num);
    //}


    /// <summary>
    /// 向元组中添加两个元素
    /// </summary>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="num"></param>
    private void AddTwoItem(int count, int item, int num = 0)
    {
        RepeatAction(count, _ =>
        {
            if (num == 0)
            {
                num = _ == 3 || _ == 4 ? -2 : 0;
            }

            AddOneItem(item, num);
            AddOneItem();
        });
    }

    void AddFiveItems(int count)
    {
        RepeatAction(count, _ =>
        {
            //AddOneItem(12, 4);
            for (var i = 0; i <= 2; i++)
            {
                var num = i == 0 ? -1 : 0;
                AddOneItem(4, num);
            }
            AddOneItem(5, -1);
            AddOneItem();
        });
    }
    /// <summary>
    /// 向元组添加3个元素
    /// </summary>
    /// <param name="count"></param>
    void AddThreeItem(int count)
    {
        RepeatAction(count, _ =>
        {
            AddOneItem(5, -2);
            AddOneItem(5, -2);
            AddOneItem();
        });
    }

    /// <summary>
    /// 添加时间
    /// </summary>
    /// <param name="num"></param>
    //void AddTwelveToTime(int num = 1)
    //{
    //    AddToList(num, 12, 13);
    //}


    /// <summary>
    /// 向List中添加数据
    /// </summary>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="num"></param>
    /// <param name="indexNum"></param>
    //void AddToList(int count = 1, int item = 1, int num = 0, int indexNum = 0)
    //{
    //    if (count == 1)
    //    {
    //        SplitByIndex(item, num);
    //    }
    //    else
    //    {
    //        var list = new List<(int, int)>();
    //        RepeatAction(count, _ => list.Add((item, num)));
    //        ListErgodic(list);
    //        list.Clear();
    //    }

    //    LastIndex += indexNum;

    //}

    /// <summary>
    /// 循环执行方法
    /// </summary>
    /// <param name="count">次数</param>
    /// <param name="action">方法</param>
    //void RepeatAction(int count, Action<int> action)
    //{
    //    for (int i = 0; i < count; i++)
    //    {
    //        action(i);
    //    }
    //}

}