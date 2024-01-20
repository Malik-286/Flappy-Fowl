using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class RemoteConfig : MonoBehaviour
{
    MainMenuUI mainMenuUI;
    public void Awake()
    {
        
        mainMenuUI = FindObjectOfType<MainMenuUI>();
        FetchDataAsync();
         
    }
    public Task FetchDataAsync()
    {
        Debug.Log("Fetching data...");
        System.Threading.Tasks.Task fetchTask =
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(
            TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

 

    void FetchComplete(Task fetchTask)
    {
        if (!fetchTask.IsCompleted)
        {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if (info.LastFetchStatus != LastFetchStatus.Success)
        {
            Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        // Fetch successful. Parameter values must be activated to use.
        remoteConfig.ActivateAsync()
          .ContinueWithOnMainThread(
            task => 
            {
               // Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
                
                  ;
                 if (Application.version != remoteConfig.GetValue("Game_Version").StringValue)
                {
                    Debug.Log("Game Version " + Application.version);
                    Debug.Log("New Updated Version " + remoteConfig.GetValue("Game_Version").StringValue);

                    mainMenuUI.EnableUpdatePanel();
                }
                
            });
    }
}
