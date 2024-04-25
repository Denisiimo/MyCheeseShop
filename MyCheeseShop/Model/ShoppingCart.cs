namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;
        public ShoppingCart()
        {
            _items = [];
        }   
        public void AddItem(Cheese cheese, int quantity)
        {

        }
    }
}
