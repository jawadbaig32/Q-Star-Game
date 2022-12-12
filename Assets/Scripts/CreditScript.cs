using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{

    public GameObject fadePanel;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.gamePlaySound.Play();
        StartCoroutine(FadePanelDelay());
       Invoke("LoadMainMenuScene", seconds);
        

    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");

    }
    

     

    IEnumerator<WaitForSeconds> FadePanelDelay()
    {
        yield return new WaitForSeconds(5f);
        fadePanel.SetActive(true);
     

    }



   
 
}
