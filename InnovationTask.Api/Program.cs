using InnovationTask.Core.Repositories;
using InnovationTask.Core.UOW;
using InnovationTask.EF;
using InnovationTask.EF.EFRepository;
using InnovationTask.EF.UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? conStr = builder.Configuration.GetConnectionString("OrderDb");
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(conStr,
        b => b.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName))
);

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(BaseRepository<>));

builder.Services.AddTransient<IUnitOfWork , UnitOfWork>();
builder.Services.AddCors(o => o.AddPolicy("ReactPolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use((context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    return next.Invoke();
});
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
