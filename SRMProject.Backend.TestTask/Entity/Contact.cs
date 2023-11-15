using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRMProject.Backend.TestTask.Entity
{
    public class Contact
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Phone]
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        #endregion
    }
}
