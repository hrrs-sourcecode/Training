using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLWebApi.Data;
using GraphQLWebApi.Mutation;
using GraphQLWebApi.Query;
using GraphQLWebApi.Schema;
using GraphQLWebApi.Services;
using GraphQLWebApi.Services.Interfaces;
using GraphQLWebApi.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ISchema,ProductSchema>();
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;
}).AddSystemTextJson();

// builder.Services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(@"server=Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=DBTrainingGraphQL; Integrated Security=True; MultipleActiveResultSets=true"));

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

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();