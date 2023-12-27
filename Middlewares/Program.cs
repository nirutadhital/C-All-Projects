var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


//middlewares
app.Use(async(context, next) =>{
    await context.Response.WriteAsync("Welcome to My App1\n");
    await next(context);
});
app.Use(async(context, next) =>{
    await context.Response.WriteAsync("Welcome to My App");
    await next(context);
});

app.Run();
