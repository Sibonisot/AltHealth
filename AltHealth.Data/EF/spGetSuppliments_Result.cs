//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AltHealth.Data.EF
{
    using System;
    
    public partial class spGetSuppliments_Result
    {
        public string Supplement_id { get; set; }
        public string Supplier_Id { get; set; }
        public string Supplement_Description { get; set; }
        public decimal Cost_excl { get; set; }
        public decimal Cost_incl { get; set; }
        public int Min_Level { get; set; }
        public int Current_Stock_Levels { get; set; }
    }
}