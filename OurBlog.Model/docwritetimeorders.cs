//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OurBlog.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class docwritetimeorders
    {
        public long FID { get; set; }
        public System.DateTime FDocWriteTime { get; set; }
        public long FDocId { get; set; }
        public long FAuthorId { get; set; }
        public int FDocClsId { get; set; }
    }
}