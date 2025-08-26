using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearRelease { get; set; }
        public double Rate { get; set; } = 0;
        public int YearCreated { get; set; }
        public ICollection<FilmsActors> FilmActors { get; set; } = new List<FilmsActors>();
    }
}
