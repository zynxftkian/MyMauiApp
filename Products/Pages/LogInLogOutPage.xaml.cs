namespace Products.Pages;

public partial class LogInLogOutPage : ContentPage
{
	public LogInLogOutPage()
	{
		InitializeComponent();
	}
	private async void OnHomeClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ProductsPage());
	}
    private async void OnAboutUsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutUsPage());
    }
    private async void OnOrdersClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrdersPage());
    }
    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        if (sender is Button button)
        {
            button.BackgroundColor = Colors.White;
        }
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        if (sender is Button button)
        {
            button.BackgroundColor = Colors.Transparent;
        }
    }
    private void OnPointerEntered3(object sender, PointerEventArgs e)
    {
        if (sender is Button button)
        {
            button.BackgroundColor = Colors.PeachPuff;
        }
    }
    private void OnPointerExited3(object sender, PointerEventArgs e)
    {
        if (sender is Button button)
        {
            button.BackgroundColor = Colors.Orange;
        }
    }
    private async void OnProductsClicked(object sender, EventArgs e)
    {
        // Navigate to the ProductsPage
        var productsPage = new ProductsPage();
        await Navigation.PushAsync(productsPage);

        await Task.Delay(600);

        // Scroll to the Products section once the page is displayed
        productsPage.OnProductsClicked(sender, e);
    }
}