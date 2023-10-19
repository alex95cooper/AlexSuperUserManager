using Microsoft.EntityFrameworkCore;

namespace AlexSuperUserManager.DAL.Models;

[PrimaryKey(nameof(NickName))]
public class User
{
    public string NickName { get; set; }
    public string FullName { get; set; }
}