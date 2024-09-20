using AOAI.Blazor.Demo.Components;
using Blazored.LocalStorage;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string deploymentName = builder.Configuration["AOAI:DeploymentName"] ?? throw new Exception("DeploymentName AppConfig Missing");
string endpoint = builder.Configuration["AOAI:Endpoint"] ?? throw new Exception("Endpoint AppConfig Missing");
string key = builder.Configuration["AOAI:Key"] ?? throw new Exception("Key AppConfig Missing");
string modelId = builder.Configuration["AOAI:ModelId"] ?? throw new Exception("ModelId AppConfig Missing");
builder.Services.AddSingleton<IChatCompletionService>(sp => new AzureOpenAIChatCompletionService(deploymentName, endpoint, key, modelId: modelId));

builder.Services.AddBlazoredLocalStorage();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
