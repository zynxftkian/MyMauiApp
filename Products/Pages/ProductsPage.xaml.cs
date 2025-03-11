using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using System.Linq; // Make sure to include this for FirstOrDefault()

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

        // ✅ Fixed: Added 'async' to support 'await DisplayAlert'
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

            // ✅ Show alert instead of navigating
            await DisplayAlert("Order Placed", "Your order has been added to the Cart page.", "OK");
        }

        // Scroll to Products section when clicking "Products" in Navbar
        private async void OnProductsClicked(object sender, EventArgs e)
        {
            await MainScrollView.ScrollToAsync(ProductsContainer, ScrollToPosition.Start, true);
        }

        // ✅ Fixed: Removed unnecessary 'Navigation.PushAsync(new ProductsPage())'
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await MainScrollView.ScrollToAsync(0, 0, true);
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

    }
}
