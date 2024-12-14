using BoardGamesStore.Data;
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
                string imagePath = $"../../image/{Image}";
                Console.WriteLine(imagePath);
                return imagePath;
            }
        }

        public string Genre
        {
            get
            {
                List<GenreGame> meow = GenreGame.Where(x => x.Game == Id).ToList();
                string genres = "";
                foreach (var game in meow)
                {
                    genres += AppConnect.model.Genres.First(x => x.Id == game.Genre).Name.ToString() + " ";
                }
                return genres;
            }
        }

        public string Publisher
        {
            get
            {
                List<PublisherGame> meow = PublisherGame.Where(x => x.Game == Id).ToList();
                string publishers = "";
                foreach (var game in meow)
                {
                    publishers += AppConnect.model.Publishers.First(x => x.Id == game.Publisher).Name.ToString() + " ";
                }
                return publishers;
            }
        }

        public string Artist
        {
            get
            {
                List<ArtistGame> meow = ArtistGame.Where(x => x.Game == Id).ToList();
                string artists = "";
                foreach (var game in meow)
                {
                    artists += AppConnect.model.Artists.First(x => x.Id == game.Artist).NameWithInitials.ToString() + " ";
                }
                return artists;
            }
        }

        public string Designer
        {
            get
            {
                List<DesignerGame> meow = DesignerGame.Where(x => x.Game == Id).ToList();
                string designer = "";
                foreach (var game in meow)
                {
                    designer +=  AppConnect.model.Designers.First(x => x.Id == game.Designer).NameWithInitials.ToString() + " ";
                }
                return designer;
            }
        }
    }

    public partial class Artists
    {
        public string NameWithInitials {
            get {
                return $"{LastName} {FirstName.First()}." + (Patronymic is null ? "" : $" {Patronymic.First()}.");
            }
        }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}" + (Patronymic is null ? "" : $" {Patronymic}");
            }
        }
    }

    public partial class Designers
    {
        public string NameWithInitials
        {
            get
            {
                return $"{LastName} {FirstName.First()}." + (Patronymic is null ? "" : $" {Patronymic.First()}.");
            }
        }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}" + (Patronymic is null ? "" : $" {Patronymic}");
            }
        }
    }
}
