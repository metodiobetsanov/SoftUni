namespace TORSHIA.ViewModels
{
    using System;

    public class CreateTaskViewModel
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public string CustomersCheckbox { get; set; }

        public string MarketingCheckbox { get; set; }

        public string FinancesCheckbox { get; set; }

        public string InternalCheckbox { get; set; }

        public string ManagementCheckbox { get; set; }
    }
}