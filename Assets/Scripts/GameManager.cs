using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    public int PlayerScore;
    public int shieldScoreCounter;
    public AudioSource btnSound;
    public AudioSource gameOverSound;
    public AudioSource destroyEnemySound;
    public AudioSource fireSound;
    public AudioSource gamePlaySound;
    public AudioSource playerDiedSound;
    public GameObject playerDiedEffect;
    public AudioSource shieldEnabledSound;
    public float enemySpeed;
    public int enemyCount = 2;



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



    public void GameOverOnDead()
    {

        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2f);
        GameOver.ShowUI();
        Time.timeScale = 0;
        PlayerControllerScript.instance.GetComponent<BoxCollider>().enabled = false;
    }




    public void GameOverColliderDisable()
    {
        GameManager.instance.gamePlaySound.volume = 1f;
        PlayerControllerScript.instance.GetComponent<BoxCollider>().enabled = false;
    }


}
