using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketRegister
{
    public class Receipt
    {
        public class Item
        {
            public int Quantity { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public double Total => (Quantity * Price);
        }

        private List<Item> _ListItems;
        private double _subTotal;
        private double _total;
        private double _tax;
        private double _taxPercent;

        public Receipt () {
            _ListItems = new List<Item>();
            _taxPercent = 10;
        }

        public void AddItem(int qty, string description, double unitprice)
        {
            var item = new Item()
            {
                Quantity = qty,
                Description = description,
                Price = unitprice
            };

            _ListItems.Add(item);
        }

        private void Calculate()
        {
            _subTotal = Math.Round(_ListItems.Sum(x => x.Total), 2);
            _tax = Math.Round(_subTotal * (_taxPercent / 100), 2);
            _total = _subTotal + _tax;
        }

        public new string ToString()
        {
            string receiptDisplay = string.Empty;
            Calculate();

            foreach (Item i in _ListItems)
            {
                receiptDisplay += $"{i.Quantity} {i.Description} @ {i.Price.ToString("C2")} = {i.Total.ToString("C2")}\r\n";
            }

            receiptDisplay += $"       SubTotal = {_subTotal.ToString("C2")}\r\n";
            receiptDisplay += $"       Tax ({_taxPercent}%) = {_tax.ToString("C2")}\r\n";
            receiptDisplay += $"       Total = {_total.ToString("C2")}";

            return receiptDisplay;
        }
    }
}
