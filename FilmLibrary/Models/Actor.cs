using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime? DateDeath { get; set; } = null;
        public ICollection<FilmsActors> FilmActors { get; set; } = new List<FilmsActors>();
    }
}
