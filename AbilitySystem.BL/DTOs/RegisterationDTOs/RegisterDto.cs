namespace AbilitySystem.BL;

public record RegisterDto(string UserName, string Email, string Password, Gender Gender);

public enum Gender
{
    Female,
    Male
}


