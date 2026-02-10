<<<<<<< Updated upstream:Proiect_medii_turism/Program.cs
using Proiect_medii_turism.Models;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.Cookies;
=======
﻿using Proiect_medii_turism.Models;
using Proiect_medii_turism.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

>>>>>>> Stashed changes:Proiect_medii_web/Proiect_medii_turism/Program.cs
=======
>>>>>>> parent of 16978ae (In mare parte e gata, de infrumusetaree mai are nevoie.)
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD
<<<<<<< Updated upstream:Proiect_medii_turism/Program.cs
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Daca nu esti logat te redirectioneaza aici
        options.AccessDeniedPath = "/AccessDenied"; // Daca incerci sa accesezi o resursa fara permisiuni
    });
=======

builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();
>>>>>>> Stashed changes:Proiect_medii_web/Proiect_medii_turism/Program.cs

=======
>>>>>>> parent of 16978ae (In mare parte e gata, de infrumusetaree mai are nevoie.)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
