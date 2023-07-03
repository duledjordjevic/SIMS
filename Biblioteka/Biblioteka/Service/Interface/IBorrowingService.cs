namespace Biblioteka.Service
{
    public interface IBorrowingService
    {
        void Add(int memberId, string bookCopyInventoryNumber);
        bool HasMemberBorrowing(int memberId);
    }
}