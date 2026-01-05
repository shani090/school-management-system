using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot config
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// REQUIRED for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/auth-service/swagger/v1/swagger.json", "Auth Service API");
        c.SwaggerEndpoint("/attendance-service/swagger/v1/swagger.json", "Attendance Service API");
        c.SwaggerEndpoint("/exams-service/swagger/v1/swagger.json", "Exams Service API");
        c.SwaggerEndpoint("/students-service/swagger/v1/swagger.json", "Students Service API");
        c.SwaggerEndpoint("/teachers-service/swagger/v1/swagger.json", "Teachers Service API");
        c.SwaggerEndpoint("/users-service/swagger/v1/swagger.json", "Users Service API");

        c.DocumentTitle = "SmartEduHub API Gateway - All Services";
        c.DefaultModelsExpandDepth(-1);
    });
}

await app.UseOcelot();

app.Run();
