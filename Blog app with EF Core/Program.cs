using Blog_app_with_EF_Core.application;
using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// add db context
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<BlogDbContext>(opt =>
     opt.UseNpgsql(builder.Configuration.GetConnectionString("BlogDb")));
// add controller
builder.Services.AddControllers();
// add services
builder.Services.AddScoped<IBlogPost, PostRepository>();
builder.Services.AddScoped<IBlogComment, CommentRepository>();

// add serialization
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);





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
