using FluentValidation;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Concrete;
using OneMusic.BusinessLayer.Validators;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Concrete;
using OneMusic.DataAccessLayer.Context;
using OneMusic.EntityLayer.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

////Ýdentity için eklendi////
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OneMusicContext>();
// Add services to the container.
builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IAlbumDal, EfAlbumDal>();
builder.Services.AddScoped<IAlbumService, AlbumManager>();

builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, IBannerManager>();

builder.Services.AddScoped<ISingerDal, EfSingerDal>();
builder.Services.AddScoped<ISingerService, ISingerManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService,ContactManager>();

builder.Services.AddScoped<IMessageDal,EfMessageDal>();
builder.Services.AddScoped<IMessageService,MessageManager>();

builder.Services.AddScoped<ISongDal, EfSongDal>();
builder.Services.AddScoped<ISongService,SongManager>();

//////Generic reposittoryde field olarak yazdýðýmýz için çaðýrdýk.//////
builder.Services.AddDbContext<OneMusicContext>();

///Using sistem reflection da dahil ediliyoruz . Fluent validation için eklendi//
/*builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())*/;//Ýngilizce olarak geldiði için aþaðýdakini kullandýk.
builder.Services.AddValidatorsFromAssemblyContaining<SingerValidator>();

builder.Services.AddControllersWithViews();

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
