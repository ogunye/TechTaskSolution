namespace CheckoutTask
{
    public interface ICheckout
    {
        int GetTotalPrice();
        void Scan(string item);
    }
}