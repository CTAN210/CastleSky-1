using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LoginValidator : MonoBehaviour
{
    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    public InputField inputEmail;
    public InputField inputPassword;
    public Text emailError;
    public Text passwordError;
    public GameObject LoginSubmitter;
    public void formValidate()
    {
        emailError.text = "";
        passwordError.text = "";


        string email = inputEmail.text.ToString();
        string password = inputPassword.text.ToString();

        validateEmail(email);
        validatePassword(password);

        if(emailError.text == "" && passwordError.text == "")
        {
            LoginSubmitter.SetActive(true);
        }

    } 
    private void validatePassword(string password)
    {
        if (password.Length == 0) {
            passwordError.text = "Please enter a password.";
        }
    }

    private void validateEmail(string email)
    {
        if (!Regex.IsMatch(email, MatchEmailPattern)) {
            emailError.text = "Invalid email.";
        } else if (email.Length == 0) {
            emailError.text = "Please enter an email.";
        }
    }
}
