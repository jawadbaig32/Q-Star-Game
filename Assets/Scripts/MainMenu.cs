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
        SceneManager.LoadScene("GamePlay");
    }



    private void Update()
    {

        PlayerPrefs.SetString("Input", takeInput.text);
    }



    public void ShowLeeaderBoard()
    {

        leaderBoardPanel.SetActive(true);

    }


    public void CloseLeeaderBoard()
    {
        leaderBoardPanel.SetActive(false);
    }
}