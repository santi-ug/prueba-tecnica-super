using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<TaskService>();

// CORS for Angular
builder.Services.AddCors(options =>
{
    // por facilidad, aunque deberia de ser el host:port exacto
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); -- lo borramos porque es un proyecto de prueba, no necesita https
app.UseCors("AllowAll");

app.MapControllers();

app.Run();

