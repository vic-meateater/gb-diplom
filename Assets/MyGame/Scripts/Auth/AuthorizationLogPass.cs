using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthorizationLogPass : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private Button _registrationButton;
    [SerializeField] private Text _errorText;
    [SerializeField] private SceneAsset _scene;

    private string _userName = "test";
    private string _userPassword = "12345678";

    private void Awake()
    {
        _userNameField.onValueChanged.AddListener(SetUserName);
        _userPasswordField.onValueChanged.AddListener(SetUserPassword);
        _registrationButton.onClick.AddListener(Submit);
    }

    private void SetUserName(string value)
    {
        _userName = value;
    }

    private void SetUserPassword(string value)
    {
        _userPassword = value;
    }

    private void Submit()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
            {
                Username = _userName,
                Password = _userPassword,
            },
            ResultCallback, ErrorCallback);
    }


    private void ResultCallback(LoginResult result)
    {
        _errorText.gameObject.SetActive(false);
        Debug.Log($"User enter: {result.LastLoginTime}");
        Debug.Log($"User PlayFabId: {result.PlayFabId}");
        Debug.Log($"User SessionTicket: {result.SessionTicket}");
        Debug.Log($"User SessionTicket: {result.PlayFabId}");
        Debug.Log($"User Entity.Id: {result.EntityToken.Entity.Id}");
        Debug.Log($"User Entity.Type: {result.EntityToken.Entity.Type}");
        Debug.Log($"User EntityToken: {result.EntityToken.EntityToken}");
        PhotonNetwork.AuthValues = new AuthenticationValues(result.SessionTicket);

        var getTitleEntityTokenRequest = new GetEntityTokenRequest();
        PlayFabAuthenticationAPI.GetEntityToken(getTitleEntityTokenRequest, Response, ErrorCallback);
        var validateEntityTokenRequest = new ValidateEntityTokenRequest();
        PlayFabAuthenticationAPI.ValidateEntityToken(validateEntityTokenRequest, onValidate, ErrorCallback);
        Debug.LogWarning("Login success");
        SceneManager.LoadScene("Lobby");
        PlayerData.PlayFabId = result.PlayFabId;
    }

    private void onValidate(ValidateEntityTokenResponse validateEntityTokenResponse)
    {
        Debug.Log($"User enter: {validateEntityTokenResponse.Entity}");  
    }
    private void Response(GetEntityTokenResponse result)
    {
        Debug.Log($"Response EntityToken: {result.EntityToken}");
        Debug.Log($"Response TokenExpiration: {result.TokenExpiration}");
        Debug.Log($"Response TokenExpiration: {result.Entity.Type}");
    }

    private void ErrorCallback(PlayFabError error)
    {
        _errorText.gameObject.SetActive(true);
        _errorText.text = error.ErrorDetails.FirstOrDefault().Value.FirstOrDefault() ?? "";
        Debug.LogError(error);
    }

    //private void Connect()
    //{
    //    PhotonNetwork.AutomaticallySyncScene = true;

    //    if (PhotonNetwork.IsConnected)
    //    {
    //        PhotonNetwork.CreateRoom("Room1");
    //    }
    //    else
    //    {
    //        PhotonNetwork.ConnectUsingSettings();
    //        PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
    //    }
    //}

    //public override void OnJoinedRoom()
    //{
    //    base.OnJoinedRoom();
    //    // Debug.Log(nameof(OnJoinedRoom));
    //    if (!PhotonNetwork.InRoom)
    //        PhotonNetwork.JoinRoom("Room1");
    //}
}