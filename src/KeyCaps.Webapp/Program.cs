using KeyCaps.Application.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var dbConfig = (DbContextOptionsBuilder opt) => {
    opt.UseSqlite(builder.Configuration["Database"]);
};

// Neuerstellung der Datenbank
{
    var opt = new DbContextOptionsBuilder();
    dbConfig(opt);
    using var db = new KeyCapsContext(opt.Options);
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

// Services hinzufügen
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KeyCapsContext>(dbConfig);

// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
