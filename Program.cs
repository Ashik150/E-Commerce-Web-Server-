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

var products = new List<Product>
{
    new Product("Laptop", 999.99m),
    new Product("Smartphone", 499.99m),
    new Product("Tablet", 299.99m)
};

app.MapGet("/", () =>
{
    return Results.Ok(products);
});

app.Run();

public record Product(string Name, decimal price);
