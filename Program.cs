using SignalRServer.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
                                                    policy.AllowAnyMethod()
                                                          .AllowAnyHeader()
                                                          .AllowCredentials()
                                                          .SetIsOriginAllowed(origin => true)
    ));

builder.Services.AddTransient<MyBusiness>();

builder.Services.AddSignalR();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //https://localhost:7003/myhub
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapControllers();
});

app.Run();
