namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales
{
    public class SaleItemResponse
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Product { get; set; } = string.Empty;

        /// <summary>
        /// The quantity sold of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to the product.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total value for this item after applying discount.
        /// </summary>
        public decimal TotalValue { get; set; }
    }
}
