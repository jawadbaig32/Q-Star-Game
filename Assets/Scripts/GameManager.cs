using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    public int PlayerScore;
    public int shieldScoreCounter;
    public GameObject laodingText;
    //public GameObject leaderboardPanel;


    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }










}
