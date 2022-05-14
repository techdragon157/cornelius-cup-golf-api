using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleScore: HoleDetail
    {
        public int Strokes { get; set; }
    }
}
