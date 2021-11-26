using System;
using System.Collections.Generic;

namespace Shopiz
{
    /// <summary>
    /// This class is designed to be a shopping cart
    /// </summary>
    public class Cart
    {
        #region private attributes
        private string _id;
        private string _name;
        private List<CartItem> _cartItems;
        private string _currency;
        private double _balance;
        #endregion private attributes

        #region public methods
        /// <summary>
        /// This constructor provides a Cart Object
        /// </summary>
        /// <param name="id">cart's unique identifier</param>
        /// <param name="name">cart's name</param>
        /// <param name="cartItems">collection of cart's items. If null, balance will be set to zero.</param>
        public Cart(string id, string name, List<CartItem> cartItems = null, string currency = "CHF", double balance = 0.0d)
        {
            _id = id;
            _name = name;
            _cartItems = cartItems;
            _currency = currency;
            _balance = balance;
        }

        /// <summary>
        /// This property gets the cart'id.
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// This property gets the cart's name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// This property gets the cart's name.
        /// </summary>
        public List<CartItem> CartItems
        {
            get
            {
                if (_cartItems == null)
                {
                    _cartItems = new List<CartItem>();
                }
                return _cartItems;
            }
        }

        /// <summary>
        /// This property gets the cart's balance (sum of item's unit price).
        /// </summary>
        public double Balance
        {
            get
            {
                double result = 0.0d;
                foreach (CartItem cartItem in _cartItems)
                {
                    result += cartItem.UnitPrice;
                }
                return result;
            }
        }

        /// <summary>
        /// This property gets the cart's currency.
        /// </summary>
        public string Currency
        {
            get
            {
                return _currency;
            }
        }

        /// <summary>
        /// This method adds a list of cart item in the current cart.
        /// </summary>
        /// <param name="cartItemsToAdd">List of cart items to add</param>
        public void AddItems(List<CartItem> cartItemsToAdd)
        {
            if (_cartItems == null)
            {
                _cartItems = new List<CartItem>();
            }

            _cartItems.AddRange(cartItemsToAdd);

        }
            /// <summary>
            /// This method empty the cart. It removes all items from the cart.
            /// </summary>
            public void Empty()
            {
                    if (_cartItems == null)
                    {
                        throw new EmptyCartException();
                    }

                    _cartItems = null;

            }
        #endregion public methods

        #region private methods
        #endregion private methods
    }

    public class CartException : Exception { }
    public class EmptyCartException : CartException { }
}
