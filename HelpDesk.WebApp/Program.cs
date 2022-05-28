using HelpDesk.Application.Contracts.Persistence;
using HelpDesk.Application.Features.Ticket.Queries.GetTicketsList;
using HelpDesk.Application.Mappings;
using HelpDesk.Infrastructure.Data;
using HelpDesk.Infrastructure.Persistence;
using HelpDesk.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile());
});

//builder.Services.AddMediatR(typeof(GetTicketsListQueryHandler));
builder.Services.AddMediatR(typeof(GetTicketsListQueryHandler).GetTypeInfo().Assembly);

builder.Services.AddDbContext<HelpDeskContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    HelpDeskContextSeed.EnsureSeedData(app.Services);
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
