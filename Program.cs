using cache_test.GraphQL;
using cache_test.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserQuery>();
builder.Services.AddTransient<UserMutation>();
builder.Services.AddGraphQLServer().AddType<UserType>().AddQueryType<UserQuery>().AddMutationType<UserMutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL("/api");
app.UseGraphQLAltair();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
