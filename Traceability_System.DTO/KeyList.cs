namespace Traceability_System.DTO
{
    public class KeyList
    {

        //基本信息
        public List<(int, int)> BasicList = new()
        {
            (14, 2), //接口No. -- Ｈｓｇ识别
            (16, 4), //MG1定子判别 --MG2转子判別
            (1, 0), //线体判别
            (4, 2) //DF箱体 -- 油泵
        };

        public List<(int, int)> StatorList = new()
        {
            (2, 1), //定子,MG1|| 
            (2, 0), //车种
            (6, 7), //年月日
            (4, 0), //序号
            (2, 0) //冲压No.
        };


        //差速器箱序列
        public List<(int, int)> DfCaseList = new()
        {
            (2, 1), //DF --箱子
            (8, 9), //年月日
            (3, 0), //加工数
        };

        //RR盖序列
        public List<(int, int)> RrCoverList = new()
        {
            (3,1),      //线体识别代码 -- 车种识别代码
            (6,7),      //年月日
            (2,1),      //制造厂代码 -- 二维码机编号
            (4,0)       //制造编号第4位 -- 制造编号第1位
        };

        //出荷序列
        public List<(int, int)> ShipmentList = new()
        {
            (4,2),      //部品识别代码 --供应商代码
            (5,1),      //工厂代码 -- 车种
            (3,4),      //年月
            (4,0),      //序号
            (1,0)       //序号末尾
        };

        //RR油泵序列
        public List<(int, int)> RrOilPumpList = new()
        {
            (6,7),      //年月日
            (4,0),      //制造编号第4位 --制造编号第1位 
            (3,1)       //生产班次 -- 泵
        };

        //工程履历
        public List<(int, int)> OneList = new()
        {
            (12, 4),    //转子工序履历
            (12, 4),    //转子工序履历（TA区域MG2）
            (28, 4),    //马达工序履历
            (10,0),    //盖体子工程履歴
            (5, 1),     //差速器工序履历
            (11, 5),    //齿轮子工序履历
            (4, 1),     //Hsg子工序履历
            (2, 1),     //Hsg子工序履历
            (29, 25),   //合体FIPG～最终工序履历
            (1, 1)      //特別
        };

        //防错

        public List<(int, int)> PokayDate = new()
        {
            (12, 13)        //防错时间
        };

        //Hsg面壳Brg压入
        public List<(int, int)> HsgBrgList = new();

        public List<(int, int)> FiveFourList = new();
    }
}