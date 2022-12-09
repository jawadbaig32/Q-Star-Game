using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    public int PlayerScore;
    public int shieldScoreCounter;
   
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
