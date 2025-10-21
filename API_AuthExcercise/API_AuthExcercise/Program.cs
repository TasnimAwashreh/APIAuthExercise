using API_AuthExcercise.API.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
