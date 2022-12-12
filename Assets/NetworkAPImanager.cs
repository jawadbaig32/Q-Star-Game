using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ihamza.webutils;
public class NetworkAPImanager : MonoBehaviour
{
    public static NetworkAPImanager instance;
    public GameObject loadingText;
    private void Awake()
    {
        instance = this;
    }
    public void saveToLeaderboard(string name, int score)
    {
        new WebRequest(this, new { nickname = name, score = score}, "https://qstargame.tecshield.io/api/score/add", RequestMethod.POST,EncodeMethod.JSON );
    }
    
    public void getFromLeaderboard(Action<string> OnDone, Action OnError)
    {
        new WebRequest(this, null, "https://qstargame.tecshield.io/api/score/get?limit=20", RequestMethod.GET,EncodeMethod.JSON,(response) => 
        {
            OnDone.Invoke(response);
           loadingText.SetActive(false);
           
        },
        (error, type)=> 
        {
            OnError.Invoke();
        });
    }
}
