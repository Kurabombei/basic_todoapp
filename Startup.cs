using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;



namespace ToDoApp
{
    public class Startup
    {
        //AddSpaStaticFiles позволяет обрабатывать статические файлы приложения Angular из определенного местоположения.Расположение файлов задается с помощью параметра configuration.RootPath.
        //В данном случае это каталог ClientApp/dist, куда, как мы указали в файле angular.json, должны помещаться скомпилированные файлы. 
        //То есть данный сервис необходим нам, когда разработка завершена, файлы Angular на typescript скомпилированы в файлы javascript, а все приложение ASP.NET Core уже развернуто на сервере в режиме production.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=tododb;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
                    
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var scope = app.ApplicationServices.CreateScope())
            //using (var context = scope.ServiceProvider.GetService<MyDbContext>())
            //    context.Database.Migrate();

            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }
            // добавляем возможности маршрутизации
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                //UseSpaStaticFiles(), который позволяет направлять запросы к нашему приложению Angular.
                app.UseSpaStaticFiles();
            }
            //app.UseSpa(), который позволяет в ответ на запросы отправлять веб-страницу по умолчанию (index.html). Этот middleware должен помещаться в конце конвейера.
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
