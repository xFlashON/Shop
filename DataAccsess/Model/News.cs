//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccsess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            this.Title = "";
            this.Content = "";
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}