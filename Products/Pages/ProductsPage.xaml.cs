namespace Products
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        // Hover effect: Show description on pointer enter
        private void OnPointerEntered2(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.Content is Grid grid && grid.Children[1] is Label descLabel)
            {
                descLabel.IsVisible = true;
            }
        }

        // Hide description on pointer exit
        private void OnPointerExited2(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.Content is Grid grid && grid.Children[1] is Label descLabel)
            {
                descLabel.IsVisible = false;
            }
        }

        // Order button click event
        private async void OnOrderClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productName = "";
            double price = 0;

            if (button.Parent is VerticalStackLayout productLayout)
            {
                Label nameLabel = productLayout.Children[0] as Label;
                productName = nameLabel.Text;

                switch (productName)
                {
                    case "SARTIK":
                        price = 80.00;
                        break;
                    case "SAUSATIK":
                        price = 80.00;
                        break;
                    case "SHUATIK":
                        price = 80.00;
                        break;
                }
            }

            var existingOrder = App.Orders.FirstOrDefault(o => o.ProductName == productName);
            if (existingOrder != null)
            {
                existingOrder.Quantity++;
            }
            else
            {
                App.Orders.Add(new OrderItem { ProductName = productName, Price = price });
            }

            await DisplayAlert("Order Placed", "Your order has been added to the Cart page.", "OK");
        }

        // Scroll to Products section when clicking "Products" in Navbar
        public async void OnProductsClicked(object sender, EventArgs e)
        {
            Button homeButton = this.FindByName<Button>("HomeButton");
            homeButton.BorderWidth = 0;
            ApplyButtonStyle(ProductsButton);
            await ProductsScrollView.ScrollToAsync(ProductsContainer, ScrollToPosition.Start, true);
        }
        // Scroll to Home (Does NOT open dropdown)
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            Button homeButton = this.FindByName<Button>("HomeButton");
            homeButton.BorderWidth = 3;
            Button productsButton = this.FindByName<Button>("ProductsButton");
            productsButton.BorderWidth = 0;
            await ProductsScrollView.ScrollToAsync(0, 0, true);
        }

        // Navigate to OrdersPage
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

        private async void OnAboutUsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutUsPage());
        }

        private async void OnLogInLogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInLogOutPage());
        }
        private void ApplyButtonStyle(Button button)
        {
            button.BackgroundColor = Color.FromHex("#531414");
            button.TextColor = Color.FromHex("#FFBD59");
            button.FontFamily = "InstrumentSerif";
            button.BorderColor = Colors.Black;  // Use Colors.White here
            button.BorderWidth = 3;
            button.WidthRequest = 150;
        }
    }
}
