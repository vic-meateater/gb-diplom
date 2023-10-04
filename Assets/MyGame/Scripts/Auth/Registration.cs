using PlayFab;
using PlayFab.ClientModels;
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

    private void Awake()
    {
        RegistrationButton.onClick.AddListener(OnRegisterButtonClick);
    }

    private void OnRegisterButtonClick() =>
        PlayFabClientAPI.RegisterPlayFabUser(PlayFabRequest(), Success, Error);

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
    }


    private void Error(PlayFabError error)
    {
        _errorMessageText.text = error.ErrorMessage;
    }
}
