//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LampNet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_ENERGY
    {
        public int siteId { get; set; }
        public Nullable<System.DateTime> energyDate { get; set; }
        public Nullable<double> energyWorktime { get; set; }
        public Nullable<double> energyStavalue { get; set; }
        public Nullable<double> energyEndvalue { get; set; }
        public Nullable<double> energyPrepower { get; set; }
        public Nullable<double> energyCurpower { get; set; }
        public Nullable<double> energyPrerate { get; set; }
        public Nullable<double> energyCurrate { get; set; }
    }
}
