using ClientesApp.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

<<<<<<< HEAD


//HttpClient -> fazer o consumo da API do Backend 
builder.Services.AddScoped(sp => new HttpClient 
{
    
 BaseAddress = new Uri("http://localhost:5019/") 

});
=======
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
>>>>>>> cf71fa97ecae1826c6e0ae7688dafaa9714af1de

await builder.Build().RunAsync();
