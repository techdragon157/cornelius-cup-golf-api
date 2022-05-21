using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleDetail
    {
        [Range(1, 18), Column(TypeName = "smallint")]
        public short Number { get; set; }

        [Range(0, 1000), Column(TypeName = "smallint")]
        public short Yards { get; set; }

        [Range(3, 7), Column(TypeName = "smallint")]
        public short Par { get; set; }

        [Range(1, 18), Column(TypeName = "smallint")]
        public short StrokeIndex { get; set; }
    }
}
