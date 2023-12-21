using IbgeApp.API.Excel.Context;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using IbgeApp.API.Excel.Model;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

// Configuração do DbContext
builder.Services.AddDbContext<MunicipioContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.UseRouting();

app.UseHttpsRedirection();

// Endpoint para upload de arquivo Excel usando HttpRequest
app.MapPost("/upload", [RequestSizeLimit(100_000_000)] async (HttpRequest request, MunicipioContext context) =>
{
    var formFiles = request.Form.Files;
    if (formFiles.Count == 0)
    {
        return Results.BadRequest("Arquivo não enviado.");
    }

    try
    {
        foreach (var file in formFiles)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet("MUNICIPIOS");
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                if (!int.TryParse(row.Cell(1).GetValue<string>(), out var codigoMunicipio))
                {
                    Results.Problem($"Falha ao processar CodigoMunicipio na linha {row.RowNumber()}");
                    continue;
                }

                var nomeMunicipio = row.Cell(2).GetValue<string>();

                var codigoUFString = row.Cell(3).GetValue<string>();
                if (!int.TryParse(codigoUFString, out var codigoUF))
                {
                    Results.Problem($"Falha ao processar CodigoUF na linha {row.RowNumber()}, Valor: {codigoUFString}");
                    continue;
                }

                var municipio = new Municipio
                {
                    CodigoMunicipio = codigoMunicipio,
                    NomeMunicipio = nomeMunicipio,
                    CodigoUF = codigoUF
                };

                context.Municipios.Add(municipio);
            }
        }

        await context.SaveChangesAsync();
        var count = context.Municipios.Count();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Erro ao processar o arquivo: {ex.Message}");
    }

    return Results.Ok("Dados importados com sucesso.");
});

app.Run();
