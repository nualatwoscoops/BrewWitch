using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BrewWitch
{
    [Table("Beers")]
    public class Beer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Style { get; set; }
        public string? Description { get; set; }
        public double? Abv { get; set; }
        public string? ImageUrl { get; set; }

    }
}
