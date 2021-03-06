using System;
using System.ComponentModel.DataAnnotations;

namespace Fifa.Core.Models
{
    public class Game : BaseEntity
    {
        [UIHint("User")]
        public int PlayerAId { get; set; }
        public User PlayerA { get; set; }

        [UIHint("User")]
        public int PlayerBId { get; set; }
        public User PlayerB { get; set; }

        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }

        [UIHint("Team")]
        public int TeamAId { get; set; }
        public Team TeamA { get; set; }

        [UIHint("Team")]
        public int TeamBId { get; set; }
        public Team TeamB { get; set; }

        public DateTime Date { get; set; }

        public int WorldId { get; set; }
        public World World { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return DateTime.Now.AddHours(-3) > Date;
            }
        }
    }
}