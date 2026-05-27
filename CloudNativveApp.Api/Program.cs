var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("StrictSecurityPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins("null")
                     .WithMethods("GET", "POST")
                     .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("StrictSecurityPolicy");
}

app.UseHttpsRedirection();

app.UseCors("StrictSecurityPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();