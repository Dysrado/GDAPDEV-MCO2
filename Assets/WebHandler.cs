using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class WebHandler : MonoBehaviour
{
    public readonly string BaseURL = "https://gdapdev-web-api.herokuapp.com/api/";
    // Start is called before the first frame update

    private void Start()
    {
    }
   public void CreateGroup()
    {
        StartCoroutine(CreateGroupRequest());
     
        
    }

    public void GetPlayers()
    {
        StartCoroutine(GetScoresRequest());
    }
    public void CreatePlayer(string name, int score) //
    {
        StartCoroutine(CreatePlayerRequest(name, score));
    }

    public void DeletePlayers()
    {
        StartCoroutine(DeleteScores());
    }
    IEnumerator DeleteScores()
    {
        Dictionary<string, object> playerParams = new Dictionary<string, object>();

        playerParams.Add("group_num", 4);
        playerParams.Add("secret", "notsleep");
        string requestBody = JsonConvert.SerializeObject(playerParams);
        byte[] requestData = Encoding.UTF8.GetBytes(requestBody);

        Debug.Log(requestBody);
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "DELETE"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.uploadHandler = new UploadHandlerRaw(requestData);
            request.downloadHandler = new DownloadHandlerBuffer();
            Debug.Log("sending delete request...");
            yield return request.SendWebRequest();
            Debug.Log($"DELETE player.response code: {request.responseCode}");
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log("DELETE success: " + request.downloadHandler.text);
            }
            else
            {
                Debug.Log("DELETE error: " + request.error);
            }
        }
    }
    IEnumerator CreatePlayerRequest(string name, int score)
    {
        Dictionary<string, object> playerParams = new Dictionary<string, object>();

        playerParams.Add("group_num", 4);
        playerParams.Add("user_name", name);
        playerParams.Add("score", score);


        string requestBody = JsonConvert.SerializeObject(playerParams);
        byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
        Debug.Log(requestBody);

        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.uploadHandler = new UploadHandlerRaw(requestData);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log("Response Code: " + request.responseCode);
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log("Success: " + request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Error: " + request.error);
            }
        }
    }
    IEnumerator GetScoresRequest()
    {
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "groups/4", "GET"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            Debug.Log("Response Code: " + request.responseCode);
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log("Success: " + request.downloadHandler.text);
                List<Dictionary<string, object>> playerList = JsonConvert.DeserializeObject
                    <List<Dictionary<string, object>>>(request.downloadHandler.text);

                foreach(Dictionary<string, object> player in playerList)
                {
                    Debug.Log($"Got player {player["user_name"]}");
                }
            }
            else
            {
                Debug.Log("Error: " + request.error);
            }
        }
    }
        // Update is called once per frame 
        IEnumerator CreateGroupRequest()
        {
            Dictionary<string, object> playerParams = new Dictionary<string, object>();

            playerParams.Add("group_num", 4);
            playerParams.Add("group_name", "Group 4");
            playerParams.Add("game_name", "Isekai Rail Shooter");
            playerParams.Add("secret", "!sleep");

            string requestBody = JsonConvert.SerializeObject(playerParams);
            byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
            Debug.Log(requestBody);

            using (UnityWebRequest request = new UnityWebRequest(BaseURL + "groups", "POST"))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                request.uploadHandler = new UploadHandlerRaw(requestData);
                request.downloadHandler = new DownloadHandlerBuffer();

                yield return request.SendWebRequest();

                Debug.Log("Response Code: " + request.responseCode);
                if (string.IsNullOrEmpty(request.error))
                {
                    Debug.Log("Success: " + request.downloadHandler.text);
                }
                else
                {
                    Debug.Log("Error: " + request.error);
                }

            }
        }
    }
