//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginHistories
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public System.DateTime LoginDateTime { get; set; }
        public Nullable<System.DateTime> LogoutDateTime { get; set; }
        public Nullable<int> CrashTypeID { get; set; }
        public string CrashReason { get; set; }
    
        public virtual CrashTypes CrashTypes { get; set; }
        public virtual Users Users { get; set; }
    }
}
