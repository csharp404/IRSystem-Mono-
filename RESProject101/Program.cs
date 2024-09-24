

using Business.BusinessLayer.BCommon.IRepository;
using Business.BusinessLayer.BCommon.Repository;
using Business.BusinessLayer.BRealES.IRepository;
using Business.BusinessLayer.BRealES.Repository;
using Business.BusinessLayer.BUser.IRepository;
using Business.BusinessLayer.BUser.Repository;
using Core.Services.Mapper;
using Data.DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
builder.Services.AddDbContext<MyDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")),
    ServiceLifetime.Scoped);
builder.Services.AddScoped<MyDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped< IRealESRepository, RealEsRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddAutoMapper(typeof(RegisterMapper));
builder.Services.AddAutoMapper(typeof(RegisterToLogin));
builder.Services.AddAutoMapper(typeof(AddressMapper));
builder.Services.AddAutoMapper(typeof(CardMapper));
builder.Services.AddAutoMapper(typeof(CommentMapper));
builder.Services.AddAutoMapper(typeof(CreateMapper));
builder.Services.AddAutoMapper(typeof(DetailsMapper));
builder.Services.AddAutoMapper(typeof(FavoriteMapper));
builder.Services.AddAutoMapper(typeof(ManagaProfileMapper));
builder.Services.AddAutoMapper(typeof(FavoriteMapper));
builder.Services.AddAutoMapper(typeof(RoomMapper));
builder.Services.AddAutoMapper(typeof(MyProfileMapper));



builder.Services.AddAutoMapper(typeof(Program));
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
app.UseCors("AllowAll");
app.UseAuthentication() ;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();