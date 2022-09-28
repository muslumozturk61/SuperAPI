using SuperBase.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAPI.DataAccess.Entities;

[Table("account")]
public class Account : EntityBase<Guid>
{
  
    [Required(ErrorMessage = "Date created is required")]
    public DateTime DateCreated { get; set; }
    [Required(ErrorMessage = "Account type is required")]
    public string? AccountType { get; set; }
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }
    public Owner? Owner { get; set; }
}