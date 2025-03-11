using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Products
{
    public partial class OrdersSummary : ContentPage
    {
        public ObservableCollection<OrderItem> Orders { get; set; }

        public OrdersSummary()
        {
            InitializeComponent();
            Orders = new ObservableCollection<OrderItem>(App.Orders);

            // Calculate total price
            double totalPrice = Orders.Sum(order => order.Price * order.Quantity);
            TotalPriceLabel.Text = $"{totalPrice}"; // No currency symbol

            BindingContext = this;
        }

        // Home Button Click Event
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }

        // Orders Button Click Event
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
