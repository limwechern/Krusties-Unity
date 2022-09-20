using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabUser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;


    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }


    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and Logged in!";
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text

        };
        //PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void ResetPasswordButton()
    {

    }

    void ONPasswordReset(SendAccountRecoveryEmailResult result)
    {

    }

    public void OnLoginSuccess()
    {

    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

}
