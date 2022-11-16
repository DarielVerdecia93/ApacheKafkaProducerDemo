using ApacheKafkaProducerDemo.ApacheKafkaConsumerDemo;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


//Add the controller KafkaConsumer
//builder.Services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();


//Add all controllers
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
