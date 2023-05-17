
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AbilitySystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Context

            var connectionString = builder.Configuration.GetConnectionString("AbilityDb");

            #region IdentityContext
            builder.Services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion

            #region AbilitySystemContext
            builder.Services.AddDbContext<AbilitySystemContext>(options =>
            options.UseSqlServer(connectionString));
            #endregion

            #endregion

            #region Identity Manager

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
               // options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IdentityContext>();

            #endregion


            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "UserSchema";
                options.DefaultChallengeScheme = "UserSchema";
            })
                .AddJwtBearer("UserSchema", options =>
                {
                    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? "";
                    var secretKyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var securityKey = new SymmetricSecurityKey(secretKyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = securityKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAdminOnly",
                    builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("AllowUsers",
                    builder => builder.RequireClaim(ClaimTypes.Role, "User", "Admin"));
            });

            #endregion

            var app = builder.Build();

            #region MiddleWares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}