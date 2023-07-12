using Microsoft.Extensions.Logging;
using ChatGptNet;
using ChatGptNet.Models;

namespace ChatGptApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddChatGpt(options =>
			{

				options.UseOpenAI(apiKey: "{YOUR API KEY HERE}",
				                organization: "{YOUR ORGANIZATION ID HERE");
				//options.ApiKey = "<your-api-key-here>";
				//options.Organization = null; // Optional
				options.DefaultModel = OpenAIChatGptModels.Gpt35Turbo;
			    options.MessageLimit = 10;  // Default: 10
			    options.MessageExpiration = TimeSpan.FromMinutes(5);    // Default: 1 hour
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

