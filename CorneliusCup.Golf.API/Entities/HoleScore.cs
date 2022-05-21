using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleScore: HoleDetail
    {
        [Range(0, 99), Column(TypeName = "smallint")]
        public short Strokes { get; set; }
    }
}
