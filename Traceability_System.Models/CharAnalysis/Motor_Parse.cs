namespace Traceability_System.Models;

public class Motor_Parse : GeneralAnalysis
{
    public List<(int, int)> MotorList = new();
    public Motor_Parse(string parse, string filePath) : base()
    {
        InputText = parse;
        MotorList = new List<(int, int)>();
    }
    public Motor_Parse(string intepu)
    {
        InputText = intepu;
    }
    public List<string> MotorSplitList()
    {
        var baseRuslt = base.SplitList();
        ExtractHsgBrgPress();
        ExtractTwelveToTime();
        RRBrgAndRR();
        Assembly();
        Stator();
        RotorMagnetize();
        RrFIGP();
        RRCover();
        Total();
        Reversal();
        baseRuslt = SubStrList.SelectMany(x => x).ToList();

        return baseRuslt;
    }

    //Hsg面壳Brg压入  -- Hsg面定位销压入
    public void ExtractHsgBrgPress()
    {
        for (int i = 0; i < 2; i++)
        {
            TwelveToTime();
            AddToList(9, 5, -2);
            AddOneItem(1);
            LastIndex += 1;
        }
    }

    //防错3 -- 4 計測日時
    public void ExtractTwelveToTime()
    {
        for (int i = 0; i < 2; i++)
        {
            TwelveToTime();             //防错3 -- 4 計測日時
        }
    }

    //RR面壳体Brg压入
    public void RRBrgAndRR()
    {
        ExtractHsgBrgPress();
    }

    //MG1 -- MG2组装・端子台紧固
    public void Assembly()
    {
        for (int i = 0; i < 2; i++)
        {
            TwelveToTime();                         //计测时间
            AddFiveOrFourList(3);           //紧固角度1軸 -- 第三轴判断代码
            LastIndex += 1;
        }


    }

    //定子本体紧固
    public void Stator()
    {
        for (int i = 0; i < 2; i++)
        {

            TwelveToTime();
        }
        AddFiveOrFourList(6, 1);
        //RotorMagnetize();

        //SplitByIndex(30);
        AddToList(6, 5, -2);
        LastIndex += 1;
    }

    //转子磁化移载
    public void RotorMagnetize()
    {
        AddTwelveToTime(3);
        //TwelveToTime();
        AddThreeFourOne(2, 1);
    }

    public void RrFIGP()
    {
        AddTwelveToTime();            //计测日時 
        AddOneItem();                //画像判定結果 -- 预备
        LastIndex += 1;
    }

    //Rr罩子组装
    public void RRCover()
    {
        AddTwelveToTime();            //计测日時 
        LastIndex += 1;
    }
    //合体1 -- 2
    public void Total()
    {
        for (int i = 0; i < 2; i++)
        {
            AddTwelveToTime();
            var numCount = i == 1 ? 10 : 11;
            AddFiveOrFourList(numCount);
            AddOneItem();
            LastIndex += 1;
        }
    }

    //箱体反转 -- 防错14计测
    public void Reversal()
    {
        AddTwelveToTime();
        LastIndex += 1;
        AddTwelveToTime(8);
    }
}