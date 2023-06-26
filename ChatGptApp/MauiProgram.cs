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
            
				options.UseOpenAI(apiKey: "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",
					organization: "org-bzcCAbw91CwmEYdtmxt0VAZg");

				options.DefaultModel = OpenAIChatGptModels.Gpt35Turbo;
			    options.MessageLimit = 16;  // Default: 10
			    options.MessageExpiration = TimeSpan.FromMinutes(5);    // Default: 1 hour
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

