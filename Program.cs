var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.MapGet("/person/{id:int}", (int id, IConfiguration config) =>
{
    return new PersonRecord(id, config.GetValue<string>("TestInfo:FirstNAme")!, config.GetValue<string>("TestInfo:LastName")!);
});
app.MapPost("/person", (PersonRecord person, IConfiguration config) =>
{
    int id = config.GetValue<int>("TestInfo:Id");
    var newPerson = person with { Id = id };
    return newPerson;
});

app.Run();
record PersonRecord(int Id, string FirstName, string LastName);