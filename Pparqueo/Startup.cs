using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Builder.Extensions;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();// Add Firebase services

        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("https://proyectoanalisis-dabe2-default-rtdb.firebaseio.com/")
            /*FirestoreDb db = FirestoreDb.Create("ProyectoAnalisis", new FirebaseCredentials(
    Path.Combine(Environment.CurrentDirectory, "firebase-adminsdk.json")));*/
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
