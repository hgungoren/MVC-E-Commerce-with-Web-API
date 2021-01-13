using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Basket
{
    public class CartItem
    {
        Dictionary<Guid, Cart> _myBasket = new Dictionary<Guid, Cart>();

        public void AddProduct(Cart product)
        {
            if (_myBasket.ContainsKey(product.ID))
            {
                _myBasket[product.ID].Quantity += 1;
                return;
            }
            _myBasket.Add(product.ID, product);
        }

        public void UpdateProduct(short count, Guid productId)
        {
            _myBasket[productId].Quantity = count;

        }

        public List<Cart> MyBasket
        {
            get
            {
                return _myBasket.Values.ToList();
            }
        }

        public void RemoveFromCart(Guid id)
        {
            if (_myBasket.ContainsKey(id))
            {
                if (_myBasket[id].Quantity > 1)
                {
                    _myBasket[id].Quantity -= 1;
                    return;
                }               
                
                    _myBasket.Remove(id);
                
            }
        }

    }

}
