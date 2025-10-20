using API_AuthExcercise;
using API_AuthExcercise.API;
using API_AuthExcercise.API.Models;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddConfiguration();
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

app.MapPost("/login", (User user, JwtTokenGenerator tokenGenerator) => {
    return new
    {
        access_token = tokenGenerator.GenerateToken(user.Username, user.Password)
    };
})
    .WithName("login");

app.MapPost("/validate", (string token, JwtTokenGenerator jwt) =>
{
    bool isValid = jwt.ValidateToken(token);
    return Results.Ok(new { valid = isValid });
});

app.Run();
