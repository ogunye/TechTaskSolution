using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTask
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _unitPrices = new Dictionary<string, int>();
        private readonly Dictionary<string, (int quantity, int specialPrice)> _specialPrices = new Dictionary<string, (int, int)>();
        private readonly Dictionary<string, int> _items = new Dictionary<string, int>();

        public Checkout(Dictionary<string, int> unitPrices, Dictionary<string, (int quantity, int specialPrice)> specialPrices)
        {
            _unitPrices = unitPrices ?? new Dictionary<string, int>();
            _specialPrices = specialPrices ?? new Dictionary<string, (int quantity, int specialPrice)>();
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _items)
            {
                if (_specialPrices.ContainsKey(item.Key))
                {
                    var specialPrice = _specialPrices[item.Key];
                    int specialPriceCount = item.Value / specialPrice.quantity;
                    int normalPriceCount = item.Value % specialPrice.quantity;

                    totalPrice += specialPriceCount * specialPrice.specialPrice + normalPriceCount * _unitPrices[item.Key];
                }
                else
                {
                    totalPrice += item.Value * _unitPrices[item.Key];
                }
            }

            return totalPrice;

        }

        public void Scan(string item)
        {
            if (_items.ContainsKey(item))
                _items[item]++;
            else
                _items[item] = 1;
        }
    }
}
