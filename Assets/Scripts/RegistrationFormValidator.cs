using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Text;

public class RegistrationFormValidator : MonoBehaviour
{

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    public InputField inputEmail;
    public InputField inputUsername;
    public InputField inputPassword;
    // public TMPro.TMP_Dropdown inputClass;
    public Text emailError;
    public Text usernameError;
    public Text passwordError;
    public Registration RegistrationSubmitter;


    public void formValidate()
    {
        emailError.text = "";
        usernameError.text = "";
        passwordError.text = "";

        string email = inputEmail.text.ToString();
        string username = inputUsername.text.ToString();
        string password = inputPassword.text.ToString();
        
        validateEmail(email);
        validateUsername(username);
        validatePassword(password);

        if(emailError.text == "" && usernameError.text == "" && passwordError.text == "")
        {
            RegistrationSubmitter.PostRegistationForm();
        }

    } 
    private void validatePassword(string password)
    {
        if (password.Length == 0) {
            passwordError.text = "Please enter a password. Only 8 - 16 Alphanumeric characters allowed.";
        } else if (password.Length < 8 || password.Length > 16) {
            passwordError.text = "Invalid password length. Only 8 - 16 Alphanumeric characters allowed.";
        } 
    }

    private void validateEmail(string email)
    {
        if (!Regex.IsMatch(email, MatchEmailPattern)) {
            emailError.text = "Invalid email.";
        } else if (email.Length == 0) {
            emailError.text = "Please enter a password.";
        }
    }

    private void validateUsername(string username)
    {
        if (username.Length == 0) {
            usernameError.text = "Please enter a username. Only 8 - 16 Alphanumeric characters allowed.";
        } else if(username.Length < 8 || username.Length > 16) {
            usernameError.text = "Invalid username length. Only 8 - 16 Alphanumeric characters allowed.";
        }
    }
}
