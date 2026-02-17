namespace MVC.ProductManagement.Domain.Enums
{
    public enum InventoryMovementType
    {
        /// <summary>
        /// Giriş (stok artışı)
        /// </summary>
        In = 1,

        /// <summary>
        /// Çıkış (stok azalışı)
        /// </summary>
        Out = 2,

        /// <summary>
        /// Sayım düzeltmesi
        /// </summary>
        Adjustment = 3,

        /// <summary>
        /// İlk stok
        /// </summary>
        InitialStock = 4
    }
}