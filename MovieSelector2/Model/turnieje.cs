//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieSelector2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class turnieje
    {
        public int id { get; set; }
        public int id_turnieju { get; set; }
        public int id_filmu { get; set; }
        public string nick { get; set; }
        public int lokata { get; set; }
        public System.DateTime data_wstawienia { get; set; }
        public Nullable<bool> losowo { get; set; }
    
        public virtual tytuly tytuly { get; set; }
    }
}