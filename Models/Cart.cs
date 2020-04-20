using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class Cart
    {
        [Newtonsoft.Json.JsonIgnore]
        public ISession Session { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            Cart cart = JsonConvert.DeserializeObject<Cart>(session?.GetString("Cart") ?? "") ?? new Cart();
            cart.Session = session;
            return cart;
        }

        public void AddItem(FoodItem foodItem, int quantity)
        {
            foreach (CartItem cartItem in CartItems)
            {
                if (cartItem.FoodItem == foodItem) 
                { 
                    cartItem.Quantity += quantity;
                    UpdateSession();
                    return;
                }
            }
            
            CartItem item = new CartItem { FoodItem = foodItem, Quantity = quantity };
            CartItems.Add(item);
            UpdateSession();
        }

        public void EditItem(FoodItem foodItem, int quantity)
        {
            foreach (CartItem cartItem in CartItems)
            {
                if (cartItem.FoodItem == foodItem)
                {
                    cartItem.Quantity = quantity;
                    UpdateSession();
                    return;
                }
            }
        }

        public void RemoveItem(FoodItem foodItem, int quantity)
        {
            foreach (CartItem cartItem in CartItems)
            {
                if (cartItem.FoodItem == foodItem)
                {
                    CartItems.Remove(cartItem);
                    UpdateSession();
                    return;
                }
            }
        }

        public void ClearList()
        {
            CartItems.Clear();
            UpdateSession();
        }

        public void UpdateSession()
        {
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }
    }
}
