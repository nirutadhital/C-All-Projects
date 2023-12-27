using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Signalrdemo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // Add SignalR service here


var app = builder.Build();

// builder.Services.AddSignalR();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// app.UseEndpoints(endpoints =>
//  {
//      endpoints.MapHub<ChatHub>("/index");
//      endpoints.MapControllerRoute(
//      name: "default",
//      pattern: "index.html");
//  });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// app.UseMvc();




app.MapRazorPages();

app.MapControllerRoute(
     name: "default",
    pattern: "{controller=Pages}/{action=Index}/{id?}");

app.Run();
