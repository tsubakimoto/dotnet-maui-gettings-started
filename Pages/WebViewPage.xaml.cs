namespace MauiSamples.Pages;

public partial class WebViewPage : ContentPage
{
	public WebViewPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        ApplyWebViewSource();
    }

    private void WebViewUrl_Completed(object sender, EventArgs e)
    {
        ApplyWebViewSource();
    }

    private void GoButton_Clicked(object sender, EventArgs e)
    {
        ApplyWebViewSource();
    }

    private void ReloadButton_Clicked(object sender, EventArgs e)
    {
        MainWebView.Reload();
    }

    private void MainWebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        if (e.Result == WebNavigationResult.Success)
        {
            WebViewUrl.Text = e.Url;
        }
    }

    private void ApplyWebViewSource()
    {
        if (Uri.TryCreate(WebViewUrl.Text, UriKind.Absolute, out var uri))
            MainWebView.Source = uri;
        else
            MainWebView.Source = "https://google.com";
    }
}