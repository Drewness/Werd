using System;
using Backend.Enumerations;

namespace Backend.Entities
{
    public class Return
    {
        public string Id { get; set; }
        public ReturnType Product { get; set; }
        public int TaxYear { get; set; }
        public User Preparer { get; set; }
        public User TaxPayer { get; set; }
        public ReturnStatus FederalStatus { get; set; }
        public DateTime FederalDate { get; set; }
        public State State { get; set; }
        public ReturnStatus StateStatus { get; set; }
        public DateTime StateDate { get; set; }
    }
}