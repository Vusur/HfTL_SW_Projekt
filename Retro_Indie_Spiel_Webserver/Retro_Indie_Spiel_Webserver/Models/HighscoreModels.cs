using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retro_Indie_Spiel_Webserver.Models
{
    /// <summary>
    /// Model für das Entity Framework für die Datenbanktabelle.
    /// </summary>
    [Table("Highscore")]
    public class HighscoreModel
    {
        
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Score { get; set; }

        public ApplicationUser User { get; set; }

    }

    /// <summary>
    /// Model für das schreiben eines Highscoreeintrages.
    /// </summary>
    public class HighscoreViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public string md5Hash { get; set; }
    }

    /// <summary>
    /// Model für die JSon List zum anzeigen auf der Homepage.
    /// </summary>
    public class HighscoreListViewModel
    {
        public static HighscoreListViewModel build(HighscoreModel model, int position)
        {
            return new HighscoreListViewModel { Name = model.User.UserName, Score = model.Score, Position = position };
        }
        
        public int Position { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}