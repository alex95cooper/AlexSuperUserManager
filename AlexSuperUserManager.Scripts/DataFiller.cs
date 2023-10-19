using AlexSuperUserManager.DAL.Models;

namespace AlexSuperUserManager.Scripts;

public static class DataFiller
{
    public static User[] GetUsers()
    {
        return new User[]
        {
            new()
            {
                NickName = "Builder458",
                FullName = "Nick Walker"
            },
            new()
            {
                NickName = "paladin",
                FullName = "Den Freeman"
            },
            new()
            {
                NickName = "vaSSil458",
                FullName = "Ben Coleman"
            },
            new()
            {
                NickName = "beerdrinker",
                FullName = "Homer Simpson"
            },
            new()
            {
                NickName = "T800",
                FullName = "Arnold Schwarzenegger"
            },
            new()
            {
                NickName = "AlexCooper",
                FullName = "Alexey Bondarenko"
            },
            new()
            {
                NickName = "Gorshok",
                FullName = "Michail Gorshenev"
            },
            new()
            {
                NickName = "paladin98",
                FullName = "William Dexter"
            },
            new()
            {
                NickName = "Senior777",
                FullName = "Anton Bakaiev"
            },
            new()
            {
                NickName = "kitty96",
                FullName = "Samanta Goodman"
            },
            new()
            {
                NickName = "power3000",
                FullName = "Rick Greenfield"
            },
            new()
            {
                NickName = "iron85maiden",
                FullName = "Bruce Dickinson"
            },
            new()
            {
                NickName = "BadGuy",
                FullName = "Quentin Tarantino"
            },
            new()
            {
                NickName = "painter79",
                FullName = "Salvador Dali"
            }
        };
    }
}