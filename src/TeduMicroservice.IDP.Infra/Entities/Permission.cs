using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using TeduMicroservice.IDP.Infra.Domain;

namespace TeduMicroservice.IDP.Infra.Entities;

public class Permission : EntityBase<long>
{
    [Key]
    [Column(TypeName = "varchar(50)")]
    public string Function { get; set; }
    
    [Key]
    [Column(TypeName = "varchar(50)")]
    public string Command { get; set; }
    
    [ForeignKey(name: "roleId")]
    public string RoleId { get; set; }

    public virtual IdentityRole Role { get; set; }

    public Permission(string function, string command, string roleId)
    {
        Function = function;
        Command = command;
        RoleId = roleId;
    }
}