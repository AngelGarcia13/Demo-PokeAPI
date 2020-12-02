1 - Add Add the Auth configuration in the requests pipeline (Startup.cs):

            app.UseAuthentication();

            app.UseAuthorization();

2 - Protect and test a controller using the [Authorize] attribute.

3 - Install:
    Microsoft.AspNetCore.Authentication.JwtBearer
    

4 - Register the Authentication support in the ConfigureServices method:

            //JWT Config
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))
                    };
                });

5 - Add the Required Configuration in the appsettings.json:

      "JWT": {
        "SecurityKey": "aaCCF1320D-05F1-48{5--._=950201F-15F8-4C82-AD35-DCAA0D52390A}06-842B-BCEA5C17B625",
        "Issuer": "localhost",
        "Audience":  "localhost"
      }

6 - Add Swagger UI configuration to support Bearer Auth Header:

                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    }
                );
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });


7 - Create a model for user credentials:

    public class UserCredentials
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

8 - Add a TokenController with the JWT generation logic:

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private JwtSecurityToken GenerateJwt(string userName)
        {
            var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return token;

        }
        // POST: api/Token
        [HttpPost]
        public IActionResult Post([FromBody] UserCredentials model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: Validate User Credentials

            //Generate JWT for the user.
            var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(model.UserName));
            return Ok(token);
        }

    }

8 - Add the package:
    Microsoft.AspNetCore.Identity.EntityFrameworkCore

9 - Change the DbContext base class to:
    IdentityDbContext<IdentityUser>

10 - Add the default behaviour to the OnModelCreating method:
    base.OnModelCreating(modelBuilder);


11 - Add Identity Support in right after the DbContext in the Startup.cs:
        
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDatabaseContext>();

12 - Add migration:
    dotnet ef migrations add IdentityAdded

13 - Update database:
    dotnet ef database update

14 - Create a UsersController for register a new user:

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCredentials model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return BadRequest("User already exists!");

            IdentityUser user = new IdentityUser()
            {
                Email = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("User creation failed! Please check user details and try again.");

            return Ok(user);
        }

    }

15 - Modify the Tokens endpoint to use the UserManager for credentials verification:

        // POST: api/Token
        [HttpPost]
        public async Task<IActionResult> PostToken([FromBody] UserCredentials model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: Validate User Credentials
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Generate JWT for the user.
                var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(model.UserName));
                return Ok(token);
            }
            return Unauthorized();
        }

16 - Add the Refresh Token Model:

    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }

17 - Change the IdentityUser to a custom one:

    public class User : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }

18 - Change the DbContext (also in the Startup) to map the new entities,  then run the migrations:
    
public class AppDatabaseContext: IdentityDbContext<User>
    {
        ...
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        ...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>().Property(p => p.RefreshTokenId)
                .ValueGeneratedOnAdd();

19 - Add a new class for handling the refresh token request:

    public class RefreshTokenRequestModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }

20 - Change the UserManager Entity type to User in the Users controller.

21 - Add the UserManager to the Token controller and add the following methods:

        // POST: api/Token
        [HttpPost]
        public async Task<IActionResult> PostToken([FromBody] UserCredentials model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.NormalizedUserName == model.UserName.ToUpper());
        
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Generate Refresh Token
                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(new RefreshToken {
                    Expires = DateTime.Now.AddDays(30),
                    Token = refreshToken
                });
                //Save Refresh Token
                await _userManager.UpdateAsync(user);
                //Generate JWT for the user.
                var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(model.UserName));
                return Ok(new {
                    accessToken = token,
                    refreshToken = refreshToken,
                    refreshTokenExpires = DateTime.Now.AddDays(30)
                });
            }
            return Unauthorized();
        }


        // POST: api/Token/Refresh
        [HttpPost("Refresh")]
        public async Task<IActionResult> PostRefreshToken([FromBody] RefreshTokenRequestModel model) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == model.RefreshToken && t.Expires > DateTime.Now));
            if (user != null)
            {
                //Generate Refresh Token
                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(new RefreshToken
                {
                    Expires = DateTime.Now.AddDays(30),
                    Token = refreshToken
                });
                //Save Refresh Token
                await _userManager.UpdateAsync(user);
                //Generate JWT for the user.
                var token = new JwtSecurityTokenHandler().WriteToken(GenerateJwt(user.UserName));
                return Ok(new
                {
                    accessToken = token,
                    refreshToken = refreshToken,
                    refreshTokenExpires = DateTime.Now.AddDays(30)
                });

            }
            return Unauthorized();
        }

        private JwtSecurityToken GenerateJwt(string userName)
        {
            var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return token;

        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                
                return Convert.ToBase64String(randomNumber) + Guid.NewGuid().ToString();
            }
        }