using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayfabScript : MonoBehaviour
{
     // Start is called before the first frame update
    
    public Scores score;
    void Start()
    {
       
    }

    // Update is called once per frame
    public void Login()
    {
        var request = new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSucess, OnError);
    }

    void OnSucess(LoginResult result){
        Debug.Log("Successful login/account create!");
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest{ DisplayName = score.username}, OnDisplayName, OnError);
    }

    void OnDisplayName(UpdateUserTitleDisplayNameResult result){
        Debug.Log(result.DisplayName + "is your new display name");
    }

    void OnError(PlayFabError error){
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    
    public void SendLeaderBoard(int score){
        
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "BaloonLeaderboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    
    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;
  
    public void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfully leaderboard sent");
    }

    public void getLeaderBoard(){
        var requestLeaderbard = new GetLeaderboardRequest{ StartPosition = 0, StatisticName = "BaloonLeaderboard", MaxResultsCount = 10};
        PlayFabClientAPI.GetLeaderboard(requestLeaderbard, OnGetLeaderboard, OnError);
    }

    void OnGetLeaderboard(GetLeaderboardResult result){

        leaderboardPanel.SetActive(true);
        foreach(PlayerLeaderboardEntry player in result.Leaderboard){
            Debug.Log("1");
            GameObject tempListing =Instantiate(listingPrefab, listingContainer);
            Debug.Log("2");
            LeaderBoardListing LL= tempListing.GetComponent<LeaderBoardListing>();
            Debug.Log("3");
            LL.playerNameText.text = player.DisplayName;
            Debug.Log("4");
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log("5");

            Debug.Log(player.DisplayName + ": " + player.StatValue);
        }
    }
    
}