using Autofac.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Traceability_System.API;
using Traceability_System.Models.FileOperation;
using Traceability_System.Models.SelectDB;
using Traceability_System.Utility;
using Youshow.Ace;
using Youshow.Ace.AspNetCore.Web;
using Youshow.Ace.Modularity;

[RelyOn(
    typeof(AceAspNetCoreWebModule)
)]
public class YoushowDemoApiModule : AceModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 加载配置

        var services = context.Services;
       // services.AddAceDbContext<YoushouDemoDbContext>();
       // 配置选项
       //Configure<AceDbContextOptions>(options => {
       //     options.UseSqlServer(); // 或options.UseMySql();
       // });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Youshow.Demo.Api", Version = "v1" });
            c.DocInclusionPredicate((_, _) => true);
        });
        services.AddCors(options =>
        {
            //开放端口
            options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                //builder.WithOrigins(new string[] { "允许跨域的url1", "允许跨域的url2" ,"..." })
                //我在给你写一种合理的(注释部分)
                builder.SetIsOriginAllowed(_=>true)
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        //注入定时器
        services.AddHostedService<FileReaderService>();
        services.AddScoped<SelectAllData>();
        services.AddScoped<RedisHelper>();
        services.AddScoped<MergeCsv>();
        //services.AddConfig(builder.Configuration);
        /*services.AddDbContext<_966KDataBaseContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("Data"));
        });*/

    }
    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //Host.CreateDefaultBuilder(args)
    //    .ConfigureWebHostDefaults(webBuilder =>
    //    {
    //        webBuilder
    //            .UseStartup<YoushowDemoApiModule>()
    //            .UseUrls("http://*:5000","https://*:5001"); // 监听所有 IP 地址的端口 5000
    //    });

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetWebApplication();
        app.UsePathBase("");
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        };
        app.UseCors("AllowSpecificOrigin");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        //app.Urls.Add("https://*:5001");
        //app.Urls.Add("http://*:5000");

        //app.Configuration.GetSection("Wechat")["AppId"];
    }
   
    // 在这里定义 miniApi
    public override void OnRouteInitialization(RouteBuilderContext context)
    {
        var builder = context.GetEndpointRouteBuilder();
       
        //builder.RegisterType<_966KDataBaseContext>().As<DbContext>().InstancePerLifetimeScope();
        builder.MapGet("/api/getname", () =>
        {
            return "Ace";
        });
    }
}