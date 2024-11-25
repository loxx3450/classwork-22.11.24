using System.ComponentModel.DataAnnotations.Schema;

namespace classwork_25._11._24.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        [ForeignKey(nameof(MovieId))]
        public int MovieId { get; set; }
    }
}
