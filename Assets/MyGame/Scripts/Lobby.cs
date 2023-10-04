using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

public class Lobby : MonoBehaviour {

    public GameObject panelLogin;
    public GameObject panelLobby;

    public Text lobbyWait;
    public Text lobbyTimeStart;
    public Text playerStatus;

    public InputField playerInputField;
    public string playerName;

	void Start ()
    {
        lobbyTimeStart.gameObject.SetActive(false);
        playerStatus.gameObject.SetActive(false);
        PanelLoginActive();

        playerName = "Player" + Random.Range(1000, 10000);
        playerInputField.text = playerName;
        GetPlayFabUsername();
    }

    private void GetPlayFabUsername()
    {
        var request = new GetPlayerProfileRequest
        {
            PlayFabId = PlayerData.PlayFabId
        };

        PlayFabClientAPI.GetPlayerProfile(request, OnGetPlayerProfileSuccess, OnGetPlayerProfileFailure);
    }

    private void OnGetPlayerProfileSuccess(GetPlayerProfileResult result)
    {
        string playFabUsername = result.PlayerProfile.DisplayName;
        Debug.Log("PlayFab Username: " + playFabUsername);
        playerInputField.text = playFabUsername;
    }

    private void OnGetPlayerProfileFailure(PlayFabError error)
    {
        Debug.LogError("Failed to get PlayFab profile: " + error.ErrorMessage);
    }

    public void PanelLobbyActive()
    {
        panelLogin.SetActive(false);
        panelLobby.SetActive(true);
    }

    public void PanelLoginActive()
    {
        panelLogin.SetActive(true);
        panelLobby.SetActive(false);
    }
}
