namespace BashSoft.Interfaces
{
    public interface IOrderedTaker
    {
        void OrderAndTake(string courseName, string comparison, int? studentsToTake = null);
    }
}