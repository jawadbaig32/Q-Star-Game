using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public InputField takeInput;
    public GameObject leaderBoardPanel;

    public void OnClick_StartBtn()
    {
        GameManager.instance.btnSound.Play();
        SceneManager.LoadScene("GamePlay");
    }

    private void Start()
    {

    }

    private void Update()
    {

        PlayerPrefs.SetString("Input", takeInput.text);
    }



    public void ShowLeeaderBoard()
    {
        GameManager.instance.btnSound.Play();
        leaderBoardPanel.SetActive(true);
    }


    public void CloseLeeaderBoard()
    {

        GameManager.instance.btnSound.Play();
        leaderBoardPanel.SetActive(false);
    }
}