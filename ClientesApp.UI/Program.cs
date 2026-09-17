using ClientesApp.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



//HttpClient -> fazer o consumo da API do Backend 
builder.Services.AddScoped(sp => new HttpClient 
{
    
 BaseAddress = new Uri("http://localhost:5019/") 

});

await builder.Build().RunAsync();
