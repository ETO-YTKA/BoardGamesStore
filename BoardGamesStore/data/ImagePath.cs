using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesStore.db
{
    public partial class Games
    {
        public string ImagePath { 
            get
            {
                return Image is null ? $"../../Images/placeholder" : $"../../Images/{Image}";
            }
        }
    }

    public partial class Artists
    {
        public string NameWithInitials {
            get {
                return Patronymic is null ? $"{LastName} {FirstName.First()}." : $"{LastName} {FirstName.First()}. {Patronymic.First()}.";
            }
        }
    }
}
