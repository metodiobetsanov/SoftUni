namespace BashSoft.Interfaces
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsMark, string comparison, int studentsToTake);
    }
}