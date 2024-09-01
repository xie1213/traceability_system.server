namespace Traceability_System.Models.ExportedMethod.interfaces
{
    public interface IContext : IDisposable
    {

        // 方法：追加数据到表单中
        void AppendData(string sheetName, object data);

        // 方法：设置表单标题
        void SetTitle(string title);

        // 方法：获取表单的数据
        object GetData();
    }
}
