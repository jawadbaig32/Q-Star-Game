using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class LeaderBoard : MonoBehaviour
{

    public string data;
    public GameObject Item;

    // Start is called before the first frame update
    void Start()
    {
        NetworkAPImanager.instance.getFromLeaderboard((response) =>
        {
            print(response);
            JSONNode N = JSON.Parse(response);
            JSONArray array = N["data"].AsArray;
            int a = 0;
            foreach (JSONObject item in array)
            {
                a++;
                GameObject i = Instantiate(Item, Item.transform.parent);
                i.transform.GetChild(0).GetComponent<Text>().text = a.ToString();
                i.transform.GetChild(1).GetComponent<Text>().text = item[0].Value;
                i.transform.GetChild(2).GetComponent<Text>().text = item[1].Value;
                i.SetActive(true);
                print(item);
            }
        },
        () =>
        {
           // GameManager.instance.leaderboardPanel.SetActive(false);
        });
    }
}