using Biblioteka.Enums;

namespace Biblioteka.Model
{
    public class BookCopy
    {
        public string InventoryNumber { get; set; } 
        public double PurchasePrice { get; set; }
        public BookCopyStatus BookCopyStatus { get;  set; } 
        public BookCopy() { }
        public BookCopy(string inventoryNumber, double purchasePrice, BookCopyStatus bookCopyStatus)
        {
            InventoryNumber = inventoryNumber;
            PurchasePrice = purchasePrice;
            BookCopyStatus = bookCopyStatus;
        }
    }
}