namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales
{
    public class CreateSaleItemRequest
    {
        /// <summary>
        /// External identity of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Descriptive name of the product (denormalized).
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied to the item.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total value of the item (unit price * quantity - discount).
        /// </summary>
        public decimal TotalValue { get; set; }

    }
}
