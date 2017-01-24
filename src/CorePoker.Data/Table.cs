using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePoker.Data
{
    public class Table
    {
        public Table()
        {
            TablePlayers = new HashSet<TablePlayer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Required]
        [MaxLength(36)]
        public string PublicId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OwnerId { get; set; }

        /// <summary>
        /// The player who created the table.
        /// </summary>
        public Player Owner { get; set; }

        public ICollection<TablePlayer> TablePlayers { get; set; }
    }
}