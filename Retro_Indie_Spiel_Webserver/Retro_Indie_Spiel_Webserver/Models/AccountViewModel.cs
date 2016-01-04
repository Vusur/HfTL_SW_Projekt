using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Retro_Indie_Spiel_Webserver.Models
{
    /// <summary>
    /// Model für das Einloggen und Registrieren eines Benutzers.
    /// </summary>             
    public class AccountIndexViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kennwort bestätigen")]
        [Compare("Password", ErrorMessage = "Das Kennwort entspricht nicht dem Bestätigungskennwort.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string md5Hash { get; set; }
    }    
}
