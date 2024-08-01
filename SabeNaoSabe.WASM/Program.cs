using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SabeNaoSabe.RazorClassLibrary.Services;
using SabeNaoSabe.WASM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IQuestionarioService, QuestionarioService>();

builder.Services.AddBlazorBootstrap();


await builder.Build().RunAsync();
