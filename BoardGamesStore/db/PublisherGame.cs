//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoardGamesStore.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class PublisherGame
    {
        public int Id { get; set; }
        public int Publisher { get; set; }
        public int Game { get; set; }
    
        public virtual Games Games { get; set; }
        public virtual Publishers Publishers { get; set; }
    }
}