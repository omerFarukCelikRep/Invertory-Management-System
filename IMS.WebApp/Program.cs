using IMS.Plugins.EFCore;
using IMS.Plugins.EFCore.Repositories;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Activities;
using IMS.UseCases.Interfaces;
using IMS.UseCases.Invertories;
using IMS.UseCases.Products;
using IMS.UseCases.Validations;
using IMS.WebApp.Areas.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IMSContext>(options =>
{
    //options.UseInMemoryDatabase("IMS");
    options.UseSqlServer(connectionString);
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<IMSContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


#region DI Repositories
//DI Repositories
builder.Services.AddTransient<IInvertoryRepository, InvertoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IInvertoryTransactionRepository, InvertoryTransactionRepository>();
builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionRepository>(); 
#endregion

#region Use Cases
//DI Use Cases
builder.Services.AddTransient<IViewInvertoriesByNameUseCase, ViewInvertoriesByNameUseCase>();
builder.Services.AddTransient<IAddInvertoryUseCase, AddInvertoryUseCase>();
builder.Services.AddTransient<IEditInvertoryUseCase, EditInvertoryUseCase>();
builder.Services.AddTransient<IViewInvertoryByIdUseCase, ViewInvertoryByIdUseCase>();

builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();

builder.Services.AddTransient<IPurchaseInvertoryUseCase, PurchaseInvertoryUseCase>();
builder.Services.AddTransient<IProduceProductUseCase, ProduceProductUseCase>();
builder.Services.AddTransient<IValidateEnoughInvertoriesForProducingUseCase, ValidateEnoughInvertoriesForProducingUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

builder.Services.AddTransient<IGetInvertoryTransactionsUseCase, GetInvertoryTransactionsUseCase>();
builder.Services.AddTransient<IGetProductTransactionsUseCase, GetProductTransactionsUseCase>(); 
#endregion

var app = builder.Build();

var scope = app.Services.CreateScope();
var imsContext = scope.ServiceProvider.GetRequiredService<IMSContext>();
//imsContext.Database.EnsureDeleted();
//imsContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
