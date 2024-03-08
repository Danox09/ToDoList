using API.Data;
using API.Services.AssignmentService;
using API.Services.PersonService;
using API.Validators;
using API.Validators.AssingmentValidator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ToDoDB>();

//SERVICES
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

//VALIDATORS
builder.Services.AddScoped<IPersonValidator, PersonValidator>();
builder.Services.AddScoped<IAssignmentValidator, AssignmentValidator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseExceptionHandler("/errors/500");
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.MapControllers();

app.Run();
