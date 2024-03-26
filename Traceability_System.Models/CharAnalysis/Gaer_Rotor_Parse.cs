namespace Traceability_System.Models.CharAnalysis;
public class Gaer_Rotor_Parse : GeneralAnalysis
{
    public List<(int, int)> GearList = new();
    public Gaer_Rotor_Parse(string parse)
    {
        InputText = parse;
    }
    public  List<string> RR_and_GearSplitList()
    {

        var baseRuslt  =  base.SplitList();
        RrBrg();
        MeasDateTime();
        DefAssembly();
        DiffGear();
        Dephasing();
        GearPress();
        DrivenNutFastening();
        DrivenNut();
        DF_BRGPress();
        DF_Fastening();
        DF_Reversal();

        MG_Magnetize();
        AxialDate();
        RotorCore();
        AxisSequence();
        CoreHeating();
        AxialPress();
        Nut_Tightening();
        RivetPress();
        Rotate_Transformer_Press();

        baseRuslt = SubStrList.SelectMany(x => x).ToList();

        return baseRuslt;
    }

    public void RrBrg()
    {
        AddTwelveToTime();      //472-483
        //9个 五个字符 小数点后两位
        AddToList(9, 5, -2, 1);//484-528


    }

    //计测时间41--差動ギヤ測定时间
    public void MeasDateTime()
    {
        //AddTwelveToTime(5);
        AddTwelveToTime(5); //530 - 589
        LastIndex += 1;
        AddTwelveToTime(2); //591 - 614
        LastIndex += 9;     
        AddTwelveToTime(2); //
    }

    //デフ組付け
    public void DefAssembly()
    {
        //4个 5字符 小数点后3位
        AddToList(4, 5, -3, 5);
        AddTwelveToTime();
    }

    //差动齿轮测量
    public void DiffGear()
    {
        AddTwelveToTime();
        AddOneItem();
        AddOneItem(5,-3);
        AddOneItem(5,-3);
        AddToList(2, 5, -3);
        LastIndex += 1;

    }

    //差速器销铆接
    public void Dephasing()
    {
        AddTwelveToTime();
        AddOneItem(6, -2);
        AddOneItem(5, -2);
        AddOneItem(6, -2);
        LastIndex += 4;
        AddTwelveToTime();
    }

    //ギア圧入
    public void GearPress()
    {
        RepeatAction(2, _ =>
        {
            AddTwelveToTime();
            AddToList(9, 5, -2);
            AddOneItem();
            LastIndex += 1;
        });


    }

    //驱动螺母紧固
    public void DrivenNutFastening()
    {
        AddTwelveToTime();
        GearList = new List<(int, int)>()
        {
            (4,-1),         //締付ﾄﾙｸ1軸
            (3,0),          //締付角度1軸
            (1,0),          //判定ｺｰﾄﾞ
            (4,-1),         //着座ﾄﾙｸ1軸
            (5,-1),         //ﾗﾝﾀﾞｳﾝ角度1軸
            (2,-1)           //緩めﾓﾆﾀｰﾄﾙｸ1軸
        };
        ListErgodic(GearList, 1);
    }

    //驱动螺母铆接
    public void DrivenNut()
    {
        TwelveToTime();

        AddOneItem(6, -2);
        AddToList(2, 5, -2, 10);

    }

    //DF BRG＋环圧入
    public void DF_BRGPress()
    {
        AddTwelveToTime();
        RepeatAction(4, _ =>
        {
            AddOneItem(6, -2);
            AddOneItem(5, -2);
        });
        AddOneItem(10);
    }

    //DF紧固
    public void DF_Fastening()
    {
        for (int i = 0; i < 2; i++)
        {
            TwelveToTime();
            RepeatAction(6, _ =>
            {
                AddOneItem(5, -2);
                AddOneItem(4);
            });
            AddOneItem();
            LastIndex += 1;
        }
    }

    //DF反转到防错38
    public void DF_Reversal()
    {
        AddTwelveToTime();
        AddOneItem(5, -2);
        LastIndex += 1;
        AddTwelveToTime(2);
        LastIndex += 4;
        AddTwelveToTime();
        LastIndex += 4;
    }


    //MG1 -- MG 磁化
    public void MG_Magnetize()
    {
        RepeatAction(2, _ =>
        {
            AddOneItem(3, -1);
            AddOneItem(4, -2);
            AddOneItem();
            LastIndex += 8;
        });
    }

    //轴移載计测日時 -- 铁芯移載计测日時
    public void AxialDate()
    {
        AddTwelveToTime();
        LastIndex += 4;
        AddTwelveToTime();
    }

    //转子铁芯序列
    public void RotorCore()
    {
        SplitByIndex(4, 0);
    }

    //轴序列
    public void AxisSequence()
    {
        AddOneItem(9);
        LastIndex += 7;
    }

    //铁芯加热
    public void CoreHeating()
    {
        AddTwelveToTime();
        AddOneItem(3, 1);      //铁芯加熱有無 -- 加热程序
        LastIndex += 2;
        AddToList(4, 3, -1);  //室温（℃）
        AddToList(2, 4, -1);
        AddToList(3, 3, -1);
        AddTwelveToTime();
        AddOneItem();
        LastIndex += 21;
    }

    //轴圧入
    public void AxialPress()
    {
        AddTwelveToTime();

        AddOneItem(5, -2);
        AddOneItem(4, -2);
        AddToList(2, 5, -2);
        AddOneItem(4, -1);
        AddOneItem(4, 0);
        AddOneItem(4, -3);
        AddOneItem(6, -2);
        AddOneItem(4, -2);
        AddOneItem(2, 1);
        LastIndex += 9;
    }

    //螺母紧固
    public void Nut_Tightening()
    {
        TwelveToTime();
        GearList = new List<(int, int)>
        {
            (4, -1), //紧固扭矩1軸
            (3, 0), //紧固角度1軸
            (2, 1), //判定代码 -- 抽样履历
            (4, -1), //着座扭矩1軸
            (5, -1), //下降角度1軸
            (2, -1), //松监视器扭矩1軸
        };
        ListErgodic(GearList, 16);

    }

    //铆接圧入
    public void RivetPress()
    {
        TwelveToTime();
        GearList = new List<(int, int)>
        {
            (5, -2), //铆接行程（0前）
            (5, -2), //铆接行程（0后）
            (4, -2), //铆接荷重
            (5, -2), //主行程
            (1, 1), //判定代码
            (5, -3), //垫圈检测传感器値
            (5, -2), //垫圈检测主値
            (1, 1), //垫圈确认位置
            (5, -2), //拐点行程
            (4, -2), //拐点负重
            (5, -2), //圧入最终行程
            (5, -2), //主行程
            (1, 1), //判定代码
        };
        ListErgodic(GearList, 17);

    }

    //旋转变压器圧入
    public void Rotate_Transformer_Press()
    {
        TwelveToTime();
        GearList = new List<(int, int)>
        {
            (5, -2), //拐点行程
            (4, -2), //拐点负重
            (5, -2), //圧入最终行程
            (5, -2), //主行程
            (2, 1), //主行程
        };

        //AddTwelveToTime();
        ListErgodic(GearList);
    }

}