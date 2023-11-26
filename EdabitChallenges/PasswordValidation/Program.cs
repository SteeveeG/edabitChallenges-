//Challenge is to Validate a password with specific rules 
// link to Challenge : https://edabit.com/challenge/etT7orqDDXJF2zGYM

using PasswordValidation;

var validator = new Validator();

Console.WriteLine("Password Validation");

var passwords = new List<string>();
//Invallid
passwords.Add("P1zz@");
passwords.Add("P1zz@P1zz@P1zz@P1zz@P1zz@");
passwords.Add("mypassword11");
passwords.Add("MYPASSWORD11");
passwords.Add("iLoveYou");
passwords.Add("Pè7$areLove");
passwords.Add("Repeeea7!");
//Valid
 
passwords.Add("H4(k+x0");                
passwords.Add("Fhg93@");     
passwords.Add("aA0!@#$%^&*()+=_-{}[]:;\""); 
passwords.Add("zZ9'?<>,.");

foreach (var password in passwords)
{
    Console.WriteLine("\n"+password);
    Console.WriteLine(validator.ValidatePassword(password));
    Thread.Sleep(500);
}