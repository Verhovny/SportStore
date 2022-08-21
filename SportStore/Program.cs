using SportStore.Models;
using SportStore.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
//добавляет все сервисы фреймворка MVC
// (в том числе сервисы для работы с аутентификацией и авторизацией, валидацией и т.д.)

// AddMvcCore(): добавляет только основные сервисы фреймворка MVC,
// а всю дополнительную функциональность, типа аутентификацией и авторизацией, валидацией и т.д.,
// необходимо добавлять самостоятельно

// AddControllersWithViews(): добавляет только те сервисы фреймворка MVC,
// которые позволяют использовать контроллеры и представления и связанную функциональность.
// При создании проекта по типу ASP.NET Core Web App (Model-View-Controller) используется именно этот метод

// AddControllers(): позволяет использовать контроллеры, но без представлений.




//builder.Services.AddControllersWithViews();
//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

// Подключение базы данных SQL Server
string connection = builder.Configuration.GetConnectionString("PostgreSQL");
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));


builder.Services.AddDbContext<DataContext>(options =>
{

    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
    {
        var m = Regex.Match(Environment.GetEnvironmentVariable("DATABASE_URL")!, @"postgres://(.*):(.*)@(.*):(.*)/(.*)");
        options.UseNpgsql($"Server={m.Groups[3]};Port={m.Groups[4]};User Id={m.Groups[1]};Password={m.Groups[2]};Database={m.Groups[5]};sslmode=Prefer;Trust Server Certificate=true");
    }
    else // In Development Environment
    {
       
        options.UseNpgsql(builder.Configuration.GetValue<string>("CONNECTION_STRING"));
    }

}
);


//builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 30))));
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));






// Это значит совместное использоване объекта класса AppTimeService во всем приложении.
// Общая функциональность для приложения
builder.Services.AddSingleton<AppTimeService>();


//Какие преимущества? Нам не придется возиться с созданием объекта, удалением его или управлением этим объектом в коде наших страниц.


// Создание служю необходимых для управления сеансом
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Сервисы, это любой функционал, который мы хотим зарегистрировать, чтобы другие части приложения, могли его использовать (эл почта, бд…).

// Configure the HTTP request pipeline.


builder.Services.AddTransient<IRepository,DataRepository>(); // одие раз создается одиночный объект для всего приложенияы
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage(); // Ошибки при отладке
app.UseHttpsRedirection();
app.UseStaticFiles(); // доставка статического содержимого
app.UseStatusCodePages(); // отправка кодов состояния в ответе

// добавляет в конвейер новый компонент, который ассоциирует данные сеанса с запросами
// и добавляет cookie наборы к ответам
// должен вызываться перед методом app.UseMvc()
app.UseSession();


//app.UseMvc();
//app.UseMvcWithDefaultRoute();
//app.MapDefaultControllerRoute();

// Определение маршрутов
app.MapControllerRoute(
  name: "default",
  pattern: "/{controller=Home}/{action=Index}/{id?}");

// тоже самое
//app.MapDefaultControllerRoute();


app.Run();
//

public class AppTimeService { };

