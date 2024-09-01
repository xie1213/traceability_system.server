using Traceability_System.Models.ExportedMethod.interfaces;

namespace Traceability_System.Models.ExportedMethod
{
    public class ContextService : IContext
    {
        private readonly List<object> _data = new List<object>();
        private string _title;

        public void AppendData(string sheetName, object data)
        {
            _data.Add(data);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetData()
        {
            return _data;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }
    }
}
