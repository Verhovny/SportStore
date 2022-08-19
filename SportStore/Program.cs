using SportStore.Models;
using SportStore.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
//��������� ��� ������� ���������� MVC
// (� ��� ����� ������� ��� ������ � ��������������� � ������������, ���������� � �.�.)

// AddMvcCore(): ��������� ������ �������� ������� ���������� MVC,
// � ��� �������������� ����������������, ���� ��������������� � ������������, ���������� � �.�.,
// ���������� ��������� ��������������

// AddControllersWithViews(): ��������� ������ �� ������� ���������� MVC,
// ������� ��������� ������������ ����������� � ������������� � ��������� ����������������.
// ��� �������� ������� �� ���� ASP.NET Core Web App (Model-View-Controller) ������������ ������ ���� �����

// AddControllers(): ��������� ������������ �����������, �� ��� �������������.




//builder.Services.AddControllersWithViews();
//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

// ����������� ���� ������ SQL Server
string connection = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));


// ��� ������ ���������� ������������ ������� ������ AppTimeService �� ���� ����������.
// ����� ���������������� ��� ����������
builder.Services.AddSingleton<AppTimeService>();


//����� ������������? ��� �� �������� �������� � ��������� �������, ��������� ��� ��� ����������� ���� �������� � ���� ����� �������.


// �������� ����� ����������� ��� ���������� �������
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// �������, ��� ����� ����������, ������� �� ����� ����������������, ����� ������ ����� ����������, ����� ��� ������������ (�� �����, ��).

// Configure the HTTP request pipeline.


builder.Services.AddTransient<IRepository,DataRepository>(); // ���� ��� ��������� ��������� ������ ��� ����� �����������
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage(); // ������ ��� �������
app.UseHttpsRedirection();
app.UseStaticFiles(); // �������� ������������ �����������
app.UseStatusCodePages(); // �������� ����� ��������� � ������

// ��������� � �������� ����� ���������, ������� ����������� ������ ������ � ���������
// � ��������� cookie ������ � �������
// ������ ���������� ����� ������� app.UseMvc()
app.UseSession();


//app.UseMvc();
//app.UseMvcWithDefaultRoute();
//app.MapDefaultControllerRoute();

// ����������� ���������
app.MapControllerRoute(
  name: "default",
  pattern: "/{controller=Home}/{action=Index}/{id?}");

// ���� �����
//app.MapDefaultControllerRoute();


app.Run();
//

public class AppTimeService { };

