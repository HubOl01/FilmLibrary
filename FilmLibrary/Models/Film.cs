using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int YearRelease { get; set; }
        public double Rate { get; set; } = 0;
        public string YearCreated { get; set; }
        public ICollection<FilmsActors> FilmActors { get; set; } = new List<FilmsActors>();
    }
}
