namespace Products.Pages
{
    public partial class AboutUsPage : ContentPage
    {
        public AboutUsPage()
        {
            InitializeComponent();
        }

        // Hover effect: Show description on pointer enter
        private void OnPointerEntered(object sender, PointerEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundColor = Colors.White;
            }
        }

        // Hide description on pointer exit
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

        // Navigate to ProductsPage and scroll to Products Section
        private async void OnProductsClicked(object sender, EventArgs e)
        {
            // Navigate to the ProductsPage
            var productsPage = new ProductsPage();
            await Navigation.PushAsync(productsPage);

            await Task.Delay(600);

            // Scroll to the Products section once the page is displayed
            productsPage.OnProductsClicked(sender, e);
        }

        // Navigate to Home (Products Page)
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }

        // Navigate to OrdersPage
        private async void OnOrdersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdersPage());
        }

        private async void OnLogInLogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInLogOutPage());
        }
    }
}
