using FuCoreApp.Core.Repository;
using FuCoreApp.Core.Services;
using FuCoreApp.Core.UnitOfWork;
using FuCoreApp.Data.Repository;
using FuCoreApp.Data.UnitOfWork;
using FuCoreApp.Mvc.ApiService;
using FuCoreApp.Mvc.Filters;
using FuCoreApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["baseUrl"]);
});
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllersWithViews(o =>
{
    o.Filters.Add(new ValidationFilter());
});

builder.Services.AddControllersWithViews(o =>
{
    o.Filters.Add(new ValidationFilter());
}
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
