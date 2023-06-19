using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    public GameObject signUpHolder;
    public TMP_InputField signUpIDInput;
    public TMP_InputField signUpEmailInput;
    public TMP_InputField signUpPasswordInput;
    public Button signUpButton;

    public GameObject logInHolder;
    public TMP_InputField logInEmailInput;
    public TMP_InputField logInPasswordInput;
    public Button logInButton;

    public GameObject thirdHolder;
    public TextMeshProUGUI userIDText;

    private Dictionary<string, Data> userData;

    public struct Data
    {
        public string id;
        public string email;
        public string password;
    }

    private void Start()
    {
        userData = new Dictionary<string, Data>();
        signUpButton.onClick.AddListener(SignUp);
        logInButton.onClick.AddListener(LogIn);
    }

    private void SignUp()
    {
        Data temp = new Data();
        temp.id = signUpIDInput.text;
        temp.email = signUpEmailInput.text;
        temp.password = signUpPasswordInput.text;


        if(!userData.ContainsKey(temp.email))
        {
            userData[temp.email] = temp;
            Debug.Log("Sign Up was successful.");
            signUpHolder.SetActive(false);
            logInHolder.SetActive(true);
        }
        else
        {
            Debug.Log("Email is already associated to another account!");
        }
    }

    private void LogIn()
    {
        string logInEmail = logInEmailInput.text;
        string logInPassword = logInPasswordInput.text;

        if(userData.TryGetValue(logInEmail, out Data storedPassword))
        {
            if(logInPassword == storedPassword.password)
            {
                userIDText.text = storedPassword.id;
                Debug.Log("Log In successful.");
                logInHolder.SetActive(false);
                thirdHolder.SetActive(true);
            }
            else
            {
                Debug.Log("Incorrect Password");
            }
        }
        else
        {
            Debug.Log("Email doesn't exist.");
        }
    }

    public void GoBack()
    {
        thirdHolder.SetActive(false);
        signUpHolder.SetActive(true);
    }

    public void SwitchToLogIn()
    {
        signUpHolder.SetActive(false);
        logInHolder.SetActive(true);
    }

    public void SwitchToSignUp()
    {
        signUpHolder.SetActive(true);
        logInHolder.SetActive(false);
    }
}
