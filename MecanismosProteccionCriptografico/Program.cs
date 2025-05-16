using Security.ASCII.Encode;
using Security.ASCII.Decode;

using Security.Base58.Encode;
using Security.Base58.Decode;

using Security.Base64.Encode;
using Security.Base64.Decode;

using Security.Binario.Encode;
using Security.Binario.Decode;

using Security.DES.Encode;
using Security.DES.Decode;

using Security.TDES.Encode;
using Security.TDES.Decode;

using Security.AES.Encode;
using Security.AES.Decode;

using Security.CarlosSuaza.Encode;
using Security.CarlosSuaza.Decode;

var corsPolicyName = "AllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(corsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//-----------------------------------------------------------------------------//

app.MapGet("/carlossuazaencode", (string Mensaje) =>
{
    return CarlosSuazaEncode.CodificarCarlosSuaza(Mensaje);
})
.WithName("GetCarlosSuazaEncode")
.WithOpenApi();

app.MapGet("/carlossuazadecode", (string Mensaje) =>
{
    return CarlosSuazaDecode.DecodificarCarlosSuaza(Mensaje);
})
.WithName("GetCarlosSuazaDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/aesencode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length >= 16 && Llave.Length <= 24)
        resultado = AESEncode.CodificarAES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave debe ser mayor o igual a 16 bytes y menor o igual a 24 bytes";
    return resultado;
})
.WithName("GetAESEncode")
.WithOpenApi();

app.MapGet("/aesdecode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length >= 16 && Llave.Length <= 24)
        resultado = AESDecode.DecodificarAES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave debe ser mayor o igual a 16 bytes y menor o igual a 24 bytes";
    return resultado;
})
.WithName("GetAESDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/tdesencode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length >= 16 && Llave.Length <= 24)
        resultado = TDESEncode.CodificarTDES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave debe ser mayor o igual a 16 bytes y menor o igual a 24 bytes";
    return resultado;
})
.WithName("GetTDESEncode")
.WithOpenApi();

app.MapGet("/tdesdecode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length >= 16 && Llave.Length <= 24)
        resultado = TDESDecode.DecodificarTDES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave debe ser mayor o igual a 16 bytes y menor o igual a 24 bytes";
    return resultado;
})
.WithName("GetTDESDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/desencode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length == 8)
        resultado = DESEncode.CodificarDES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave es menor a 8 bytes";
    return resultado;
})
.WithName("GetDESEncode")
.WithOpenApi();

app.MapGet("/desdecode", (string Mensaje, string Llave) =>
{
    string resultado;
    if(Llave.Length == 8)
        resultado = DESDecode.DecodificarDES(Mensaje, Llave);
    else
        resultado = "Longitud de la llave es menor a 8 bytes";
    return resultado;
})
.WithName("GetDESDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/asciiencode", (string Mensaje) =>
{
    return ASCIIEncode.CodificarASCII(Mensaje);
})
.WithName("GetASCIIEncode")
.WithOpenApi();

app.MapGet("/asciidecode", (string Mensaje) =>
{
    return ASCIIDecode.DecodificarASCII(Mensaje);
})
.WithName("GetASCIIDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/base58encode", (string Mensaje) =>
{
    return Base58Encode.CodificarBase58(Mensaje);
})
.WithName("GetBase58Encode")
.WithOpenApi();

app.MapGet("/base58decode", (string Mensaje) =>
{
    return Base58Decode.DecodificarBase58(Mensaje);
})
.WithName("GetBase58Decode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/base64encode", (string Mensaje) =>
{
    return Base64Encode.CodificarBase64(Mensaje);
})
.WithName("GetBase64Encode")
.WithOpenApi();

app.MapGet("/base64decode", (string Mensaje) =>
{
    return Base64Decode.DecodificarBase64(Mensaje);
})
.WithName("GetBase64Decode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.MapGet("/binarioencode", (string Mensaje) =>
{
    return BinarioEncode.CodificarBinario(Mensaje);
})
.WithName("GetBinarioEncode")
.WithOpenApi();

app.MapGet("/binariodecode", (string Mensaje) =>
{
    return BinarioDecode.DecodificarBinario(Mensaje);
})
.WithName("GetBinarioDecode")
.WithOpenApi();

//-----------------------------------------------------------------------------//

app.Run();
