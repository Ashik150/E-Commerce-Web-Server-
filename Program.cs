using Microsoft.AspNetCore.Http.Connections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

List<Category> categories = new List<Category>();

app.MapGet("/", () =>
{
    return "Welcome to E-Commerce Site";
});

//Read Categories
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

//Post Categories
app.MapPost("/api/categories", () =>
{
    var category = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = "Electronics",
        Description = "All electronic items",
        CreatedAt = DateTime.UtcNow
    };
    categories.Add(category);
    return Results.Created($"/api/categories/{category.CategoryId}",category);
});

app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

};
