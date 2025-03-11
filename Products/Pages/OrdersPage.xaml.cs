using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Products.Pages;

public partial class OrdersPage : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<OrderItem> Orders => App.Orders;

    public string TotalAmount => $"{Orders.Sum(o => o.TotalPrice):N2}";

    public OrdersPage()
    {
        InitializeComponent();
        BindingContext = this;
        Orders.CollectionChanged += (s, e) => OnPropertyChanged(nameof(TotalAmount));
    }

    private void OnMinusClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is OrderItem order)
        {
            if (order.Quantity > 1)
            {
                order.Quantity--;
            }
            else
            {
                App.Orders.Remove(order);
            }
            OnPropertyChanged(nameof(TotalAmount)); // Update total amount when an item is removed
        }
    }

    private void OnPlusClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is OrderItem order)
        {
            order.Quantity++;
            OnPropertyChanged(nameof(TotalAmount)); // Update total amount
        }
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductsPage());
    }

    public new event PropertyChangedEventHandler PropertyChanged;
    protected new void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private async void OnCheckOutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrdersSummary());
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
