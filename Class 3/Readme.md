0 - Add the ApiExplorerSettings annotation to controllers

    [ApiExplorerSettings(GroupName = "v2")]

1 - Add Swagger Package: Install-Package Swashbuckle.AspNetCore and add the ReportApiVersions to the Versioning config:

            services.AddApiVersioning(config =>
                {
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.ReportApiVersions = true;
                });
             
            services.AddControllers()
                .AddXmlSerializerFormatters();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Poke API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Angel Garcia",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/_angelgarcia13"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Poke API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Angel Garcia",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/_angelgarcia13"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeAPI V1");

                c.SwaggerEndpoint("/swagger/v2/swagger.json", "PokeAPI V2");
            });

2 - Add response type annotations 
    
        [ProducesResponseType(200, Type = typeof(Pokemon))]

3 - Create a simple service using an Interface for its abstraction, register as Scoped.

        public interface IMessageWriter
        {
            void Write(string message);
        }


4 - Install EF Core 

    Microsoft.EntityFrameworkCore.Sqlite

5 - Add a new folder "Data" and create the DbContext "AppDatabaseContext":

    public class AppDatabaseContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public AppDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasKey(p => p.Code);
        }
    }

6 - Register the DbContext in the Startup.cs, first intall the provider Microsoft.EntityFrameworkCore.Sqlite:


            services.AddDbContext<AppDatabaseContext>(
                options => options.UseSqlite("Data Source=pokemons.db"));

7 - Create the database

        dotnet tool install --global dotnet-ef
        dotnet add package Microsoft.EntityFrameworkCore.Design
        dotnet ef migrations add InitialCreate --output-dir Data/Migrations
        dotnet ef database update

8 - Generate a change in the model and add a migration then update.

9 - Use the AppDatabaseContext in the controllers.

10 - Seed the DB using HasData in the model builder for the entity.