using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {

        /// <summary>
        /// Date and time the sale was performed.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// External identity of the customer (from the Customer domain).
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Descriptive name of the customer at the time of sale (denormalized).
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// External identity of the branch.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Descriptive name of the branch (denormalized).
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Total value of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// List of products involved in the sale.
        /// </summary>
        public List<Products> Items { get; set; } = new();

        /// <summary>
        /// Indicates whether the sale has been canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        public string SaleNumber => SaleNumber;

        string ISale.Id => Id.ToString();
    }
}
