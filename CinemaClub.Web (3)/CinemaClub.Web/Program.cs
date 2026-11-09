using CinemaClub.Web.Components;
using CinemaClub.Web.Models;
using CinemaClub.Web.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using static CinemaClub.Web.Services.IMovieService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddDbContext<CinemaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("CinemaDb")).UseLowerCaseNamingConvention());

builder.Services.AddScoped<IMovieService, MovieService>();


//IMovieService movieService = new MovieService(new CinemaDbContext());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
