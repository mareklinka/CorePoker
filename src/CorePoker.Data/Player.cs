using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoker.Data
{
    public class Player
    {
        public Player()
        {
            OwnedTables = new HashSet<Table>();
            MemberTables = new HashSet<TablePlayer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nickname { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The tables this player created.
        /// </summary>
        [InverseProperty(nameof(Table.Owner))]
        public ICollection<Table> OwnedTables { get; set; }

        /// <summary>
        /// The tables this player plays at.
        /// </summary>
        public ICollection<TablePlayer> MemberTables { get; set; }
    }
}