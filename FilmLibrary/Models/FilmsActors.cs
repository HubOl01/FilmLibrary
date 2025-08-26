using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Models
{
    public class FilmsActors
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public Film Film { get; set; } = null!;
        public Actor Actor { get; set; } = null!;
    }
}
