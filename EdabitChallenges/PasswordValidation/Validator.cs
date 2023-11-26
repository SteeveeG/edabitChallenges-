using System.Text.RegularExpressions;

namespace PasswordValidation;

public class Validator
{
    Regex upperCaseRegex = new("^[A-Z]+$");
    Regex lowerCaseRegex = new("^[a-z]+$");
    Regex AlphabeticRegex = new("^[A-Za-z]+$");
    Regex numbersRegex = new("^[0-9]+$");
    Regex NumbersLowerCaseRegex = new("^[a-z0-9]+$");
    Regex NumbersUpperCaseRegex = new("^[A-Z0-9]+$");
    Regex SpecialCharactersRegex = new("^[a-zA-Z0-9!@#$%^&*()+=_-{}\\[\\]:;\"'<>?,.-]+$");
    


    public string ValidatePassword(string password)
    {
        switch (password.Length)
        {
            case > 24:
                return "too long";
            case < 6:
                return "too short";
        }

        if (upperCaseRegex.IsMatch(password))
        {
            return "Missing Numbers and lowercase";
        }
  
        if (lowerCaseRegex.IsMatch(password))
        {
            return "Missing Numbers and uppercase";
        }
        if (numbersRegex.IsMatch(password))
        {
            return "Missing lowercase and uppercase";
        }
        if (AlphabeticRegex.IsMatch(password))
        {
            return "Missing Numbers";
        }
        if (NumbersLowerCaseRegex.IsMatch(password))
        {
            return "Missing uppercase";
        }
        if (NumbersUpperCaseRegex.IsMatch(password))
        {
            return "Missing lowercase";
        }
        if (!SpecialCharactersRegex.IsMatch(password))
        { 
            return "Special Character not Supported";
        }
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] == password[(i + 1) % password.Length] &&
                password[i] == password[(i + 2) % password.Length])
            {
                return "Maximum of 2 repeated characters";
            }
        }

        return "OK !";
    }
}