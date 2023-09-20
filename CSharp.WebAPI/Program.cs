using CSharp.WebAPI;
using Microsoft.FSharpLu.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(x =>
    x.SerializerSettings.Converters.Add(
        new CompactUnionJsonConverter(
            FSharpInterop.ToOption<bool>(true),
            FSharpInterop.ToOption<bool>(false)
        )
   )
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
