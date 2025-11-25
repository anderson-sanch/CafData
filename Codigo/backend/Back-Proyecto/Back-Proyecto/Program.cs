using Back_Proyecto;

var builder = WebApplication.CreateBuilder(args);

// Injectamos TODO desde AddExternal
builder.Services.AddExternal(builder.Configuration);

// Controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Si tienes autenticación, iría aquí:
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.Run();
