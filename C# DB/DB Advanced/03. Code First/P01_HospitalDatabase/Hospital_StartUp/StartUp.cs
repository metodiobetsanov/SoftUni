namespace Hospital_StartUp
{
    using System;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    class StartUp
    {
        static void Main()
        {
            using (var db = new HospitalContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
