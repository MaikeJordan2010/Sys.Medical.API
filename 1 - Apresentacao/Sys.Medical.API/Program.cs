using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sys.Medical.Aplicacao._Injecao;
using Sys.Medical.Dominio.Sistemicas;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
                .WithOrigins("*")
                .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


///////////  VAIDANDO AUTENTICAÇÃO POR METODO JWT BEARER
builder.Services.AddAuthentication(x =>
{
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>                            
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            RequireExpirationTime = false,
            ValidateIssuer = false,                                          
            ValidateAudience = false,                                        
            ValidateLifetime = true,                                        
            ValidateIssuerSigningKey = true,                                
            ValidIssuer = TokenKey.Issuer,                                  
            ValidAudience = TokenKey.Audience,                          
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey.key))
        };

        options.Events = new JwtBearerEvents                                        
        {
            OnAuthenticationFailed = context =>                                     
                {
                    Console.WriteLine("Token Inválido" + context.Exception.Message);    
                    return Task.CompletedTask;
                },
            OnTokenValidated = context =>                                           
                {
                    Console.WriteLine("Token Válido" + context.SecurityToken);          
                    return Task.CompletedTask;
                }
        };

    });



builder.Services.AddInfraestrutura();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
