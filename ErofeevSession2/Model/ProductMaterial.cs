//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ErofeevSession2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductMaterial
    {
        public int ProductID { get; set; }
        public int MaterialID { get; set; }
        public Nullable<double> Count { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
    }
}
