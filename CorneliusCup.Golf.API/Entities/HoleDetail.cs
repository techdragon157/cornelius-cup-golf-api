using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleDetail
    {
        public short Number { get; set; }

        public short Yards { get; set; }

        public short Par { get; set; }

        public short StrokeIndex { get; set; }
    }
}
