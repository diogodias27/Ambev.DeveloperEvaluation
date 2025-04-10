namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de uma venda.
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Obtém o identificador único da venda.
        /// </summary>
        /// <returns>O ID do usuário como uma string.</returns>
        public string Id { get; }

        /// <summary>
        /// Obtém o numero da venda.
        /// </summary>
        /// <returns>O nome de usuário.</returns>
        public string SaleNumber { get; }
    }
}
