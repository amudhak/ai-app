using ChatGptNet;
using ChatGptNet.Models;

namespace ChatGptApp;

public partial class MainPage : ContentPage
{
	private IChatGptClient _chatGptClient;

	public MainPage()
	{
		InitializeComponent();
		this.Loaded += MainPage_Loaded;
	}

	private void MainPage_Loaded(object sender, EventArgs e)
	{
		_chatGptClient = Handler.MauiContext.Services.GetService<IChatGptClient>();
	}

	private async void OnEnterClicked(object sender, EventArgs e)
	{
		await GetResponse();
	}

	private async Task GetResponse()
	{
		if (string.IsNullOrWhiteSpace(TextBox.Text))
        {
            await DisplayAlert("Empty entry", "Please enter some text", "OK");
            return;
        }

        if (_sessionGuid == Guid.Empty)
        {
            _sessionGuid = Guid.NewGuid();
        }

        ChatGptResponse response = await _chatGptClient.AskAsync(_sessionGuid, TextBox.Text);
        RLabel.Text = response.GetMessage();
    }

    private Guid _sessionGuid = Guid.Empty;

}
