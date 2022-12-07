using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour
{
    public float time, seconds;
    public Image splashBar;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 5f;
        Invoke("LoadScene", seconds);
    }


    private void Update()
    {
        LoadTime();
    }


    //Time To Load 
    public void LoadTime()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            splashBar.fillAmount = time / seconds;
        }
    }

    //Load Scene
    public void LoadScene()
    {
        SceneManager.LoadScene("CreditsScene");

    }
}
