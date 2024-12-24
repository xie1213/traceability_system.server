using System.Data;

namespace Traceability_System.Utility;

public static class TModels
{
    //public static TModel DataRowToModel<TModel>(this DataRow dr)
    //{
    //    Type type = typeof(TModel);
    //    TModel md = (TModel)Activator.CreateInstance(type);
    //    foreach (var prop in type.GetProperties())
    //    {
    //        if (dr[prop.Name] == DBNull.Value)
    //        {
    //            if (prop.PropertyType == typeof(DateTime))
    //            {
    //                dr[prop.Name] = DBNull.Value;
    //            }
    //            else if (prop.PropertyType.IsValueType)
    //            {
    //                dr[prop.Name] = Activator.CreateInstance(prop.PropertyType);
    //            }
    //        }
    //        if (dr[prop.Name] != DBNull.Value)
    //        {
    //            // 之后的转换逻辑
    //            prop.SetValue(md, dr[prop.Name]);

    //        }
    //    }
    //    return md;
    //}

    public static TModel DataRowToModel<TModel>(this DataRow dr) where TModel : new()
    {
        string valus = "";
        try
        {
            Type type = typeof(TModel);
            TModel model = new TModel();
            foreach (var prop in type.GetProperties())
            {
                if (!prop.CanWrite || !dr.Table.Columns.Contains(prop.Name) || dr[prop.Name] == DBNull.Value)
                {
                    continue;
                }

                object value = dr[prop.Name];
                valus = prop.Name;
                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                // 为了处理可空类型和非可空类型，需要先转换为合适的类型
                object safeValue = (value == null) ? null : Convert.ChangeType(value, propType);

                prop.SetValue(model, safeValue);
            }
            return model;
        }
        catch (Exception e)
        {

            Console.WriteLine("字段解析失败"+valus + e.Message);
            throw;
        }
       
    }


    public static object DataRowToType(this DataRow dr, Type modelType)
    {
        string valus = "";
        object model = Activator.CreateInstance(modelType);
        try
        {
            foreach (var prop in modelType.GetProperties())
            {
                object value = dr[prop.Name];

                valus = prop.Name;
                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                // 为了处理可空类型和非可空类型，需要先转换为合适的类型
                object safeValue = (value == null) ? null : Convert.ChangeType(value, propType);

                prop.SetValue(model, safeValue);
                // 将值设置到目标对象的属性
                //prop.SetValue(model, Convert.ChangeType(value, prop.PropertyType));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(valus + "字段错误" +ex.Message);
            throw;
        }

        return model;
    }
    private static object GetDefaultValue(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }
}