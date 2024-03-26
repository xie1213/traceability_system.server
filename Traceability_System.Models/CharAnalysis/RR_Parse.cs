namespace Traceability_System.Models;
public class RR_Parse : GeneralAnalysis
{
    public List<(int, int)> RrList;
    public RR_Parse(string txt, string rrFliePath)
    {
        InputText = txt;
        RrList = new List<(int, int)>();
    }

    public RR_Parse (string txt)
    {
        InputText = txt;
    }

    public List<string> RR_SplitList()
    {

        base.SplitList();
        RrBrg();
        var result = SubStrList.SelectMany(x => x).ToList();

        return result;
    }

    //RrBrg压入
    public void RrBrg()
    {
        AddTwelveToTime();
        AddToList(9, 5, -2);
        LastIndex += 1;
        for (int i = 0; i < 5; i++)
        {
            TwelveToTime();
        }
        LastIndex += 1;
        for (int i = 0; i < 2; i++)
        {
            TwelveToTime();
        }
        LastIndex += 9;
    }
}