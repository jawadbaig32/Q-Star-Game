using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public static GameOver instance;
	
	public static GameOver ShowUI()
	{
		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("Panels/GameOverPanel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<GameOver>();
		}
		return instance;
	}


    public void OnClick_YesBtn()
    {

		SceneManager.LoadScene("GamePlay");

    }

	public void OnClick_NoBtn()
	{
        SceneManager.LoadScene("MainMenu");


    }



}
