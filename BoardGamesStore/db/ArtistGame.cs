//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoardGamesStore.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArtistGame
    {
        public int id { get; set; }
        public int Artist { get; set; }
        public int Game { get; set; }
    
        public virtual Artists Artists { get; set; }
        public virtual Games Games { get; set; }
    }
}
