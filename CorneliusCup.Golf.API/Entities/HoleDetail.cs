using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleDetail
    {
        public int Number { get; set; }

        public int Yards { get; set; }

        public int Par { get; set; }

        public int StrokeIndex { get; set; }
    }
}
