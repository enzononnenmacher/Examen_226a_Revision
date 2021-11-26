using System;

namespace Shopiz
{
    /// <summary>
    /// This class is designed to be a shopping cart item
    /// </summary>
    public class CartItem
    {
        #region private attributes
        private string _id;
        private string _longDescription;
        private double _unitPrice;
        private string _currency;
        #endregion private attributes

        #region public methods
        /// <summary>
        /// This constructor provides a Cart Object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="longDescription"></param>
        /// <param name="unitPrice"></param>
        public CartItem(string id, string longDescription, double unitPrice, string currency = "CHF")
        {
            _id = id;
            _longDescription = longDescription;
            _unitPrice = unitPrice;
            _currency = currency;
        }

        /// <summary>
        /// This property gets the cartitem's id
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// This property gets the cartitem's long description
        /// </summary>
        public string LongDescription
        {
            get
            {
                return _longDescription;
            }
        }

        /// <summary>
        /// This property gets and set the CartItem's unit price
        /// </summary>
        /// <exception cref="TooSmallValueException">When unit price to set is smaller than 1.00</exception>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                _unitPrice = value;

                if (_unitPrice < 1.00)
                {
                    throw new TooSmallValueException();
                }
            }
        }

        /// <summary>
        /// This property gets the cart's currency
        /// </summary>
        public string Currency
        {
            get
            {
                return _currency;
            }
        }

        #endregion public methods

        #region private methods
        #endregion private methods
    }

    public class CartItemException : Exception { }
    public class TooSmallValueException : CartItemException { }
}
