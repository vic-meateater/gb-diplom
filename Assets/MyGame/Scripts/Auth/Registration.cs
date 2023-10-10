using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Registration : MonoBehaviour
{
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userEmailField;
    [SerializeField] private InputField _userPasswordField;
    [field: SerializeField] public Button RegistrationButton { get; private set; }
    [SerializeField] private UnityEngine.UI.Text _errorMessageText;
    [SerializeField] private Button _alreadyRegButton;
    [SerializeField] private Canvas _signInCanvas;
    [SerializeField] private Canvas _regCanvas;

    private void Awake()
    {
        RegistrationButton.onClick.AddListener(OnRegisterButtonClick);
        _alreadyRegButton.onClick.AddListener(OnAlreadyRegButtonClick);
    }

    private void OnAlreadyRegButtonClick()
    {
        _regCanvas.gameObject.SetActive(false);
        _signInCanvas.gameObject.SetActive(true);
    }

    private void OnRegisterButtonClick()
    {
        Debug.Log("Button click");
        PlayFabClientAPI.RegisterPlayFabUser(PlayFabRequest(), Success, Error);
    }

    private RegisterPlayFabUserRequest PlayFabRequest()
    {
        var request = new RegisterPlayFabUserRequest();
        request.Username = _userNameField.text;
        request.Email = _userEmailField.text;
        request.Password = _userPasswordField.text;
        request.RequireBothUsernameAndEmail = true;
        request.DisplayName = _userNameField.text;
        
        return request;
    }

    private void Success(RegisterPlayFabUserResult result)
    {
        Debug.Log("Register PlayFab Success");
        OnAlreadyRegButtonClick();
    }


    private void Error(PlayFabError error)
    {
        _errorMessageText.text = error.ErrorMessage;
    }
}
