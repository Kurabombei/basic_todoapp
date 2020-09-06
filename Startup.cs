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
        //AddSpaStaticFiles ��������� ������������ ����������� ����� ���������� Angular �� ������������� ��������������.������������ ������ �������� � ������� ��������� configuration.RootPath.
        //� ������ ������ ��� ������� ClientApp/dist, ����, ��� �� ������� � ����� angular.json, ������ ���������� ���������������� �����. 
        //�� ���� ������ ������ ��������� ���, ����� ���������� ���������, ����� Angular �� typescript �������������� � ����� javascript, � ��� ���������� ASP.NET Core ��� ���������� �� ������� � ������ production.
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

            // ���� ���������� � �������� ����������
            if (env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();
            }
            // ��������� ����������� �������������
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                //UseSpaStaticFiles(), ������� ��������� ���������� ������� � ������ ���������� Angular.
                app.UseSpaStaticFiles();
            }
            //app.UseSpa(), ������� ��������� � ����� �� ������� ���������� ���-�������� �� ��������� (index.html). ���� middleware ������ ���������� � ����� ���������.
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
