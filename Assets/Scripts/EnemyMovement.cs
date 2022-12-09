using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    

    public Transform target;
    Vector3 target2;
    private float speed;
    public int enemyHealth = 3;
    public int scoreToGiveonDeath;
    public Transform lookAttarget;

    // Start is called before the first frame update
    void Start()
    {
        target2 = PlayerControllerScript.instance.transform.position;
        SetAngle();
        // transform.LookAt(EnemySpawning.instance.lookAttarget.transform);
        //transform.rotation = Quaternion.LookRotation(target2);
        // transform.rotation = Quaternion.FromToRotation(transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z), PlayerControllerScript.instance.transform.position = new Vector3(PlayerControllerScript.instance.transform.position.x, PlayerControllerScript.instance.transform.position.y, PlayerControllerScript.instance.transform.position.z));
    }

    private void Update()
    {
        MoveEnemy_TowardsPlayer();
        //transform.eulerAngles = new Vector3(90f, 0f, 0f);
        //transform.eulerAngles = new Vector3(90f, 0f, 0f);
        // transform.LookAt(lookAttarget);
        //  transform.LookAt(target2);
        //   transform.LookAt(target2);
    }


    //Enemey Movement towards Player
    public void MoveEnemy_TowardsPlayer()
    {
        speed = Random.Range(0.5f, 2f);
        Vector3 startPos = transform.position;
        transform.position=Vector3.MoveTowards(startPos, target2, speed*Time.deltaTime);
       // transform.LookAt(target2);
    }





    // Destroy on Collision with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject b = this.gameObject;
            EnemySpawning.instance.spawnedObjList.Remove(b);
            Destroy(b, 0.1f);

            //Do When Shield Enabled 
            if (PlayerControllerScript.instance.shieldEnabled == true)
            {
                PlayerControllerScript.instance.shieldImage.SetActive(true);
                PlayerControllerScript.instance.playerhealth -= 0;
                PlayerControllerScript.instance.shieldCounter -= 1;

                if (PlayerControllerScript.instance.shieldCounter <= -1)
                {
                    PlayerControllerScript.instance.shieldImage.SetActive(false);
                }
                if (PlayerControllerScript.instance.shieldCounter <= -2)
                {
                    PlayerControllerScript.instance.shieldEnabled = false;
                }
            }
            //Do when Shield Disabled
            if (PlayerControllerScript.instance.shieldEnabled == false)
            {
                PlayerControllerScript.instance.shieldImage.SetActive(false);
                PlayerControllerScript.instance.playerhealth -= 1;
                if (PlayerControllerScript.instance.playerhealth == 2)
                {
                    PlayerControllerScript.instance.playerH_Bar_green.SetActive(false);
                    PlayerControllerScript.instance.playerH_Bar_yellow.SetActive(true);
                }
              else  if (PlayerControllerScript.instance.playerhealth == 1)
                {
                    PlayerControllerScript.instance.playerH_Bar_yellow.SetActive(false);
                    PlayerControllerScript.instance.playerH_Bar_red.SetActive(true);
                }
              else  if (PlayerControllerScript.instance.playerhealth == 0)
                {
                    PlayerControllerScript.instance.playerH_Bar_red.SetActive(false);
                }
            else    if (PlayerControllerScript.instance.playerhealth < 0)
                {
                    GameOver.ShowUI();
                }
            }
        }
    }


    // EnemyHealth
    public void ReceiveDamage(int damageValue)
    {
        enemyHealth -= damageValue;
        if (enemyHealth == 0)
        {
            EnemyDied();


        }
    }

   



    public void SetAngle()
    {
        //transform.eulerAngles = new Vector3(90f, 0f, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(90f, this.transform.rotation.eulerAngles.y, 0f));
        print("angle");

    }

    //Enemy Death Function
    public void EnemyDied()
    {
        GameObject b = this.gameObject;
        Destroy(b);
        GameObject o = Instantiate(PlayerControllerScript.instance.enemy_DestroyEffect, this.transform.position, transform.rotation);
       // Destroy(o.gameObject, 2);
        EnemySpawning.instance.spawnedObjList.Remove(b);
        GameManager.instance.PlayerScore += scoreToGiveonDeath;
        GameManager.instance.shieldScoreCounter += scoreToGiveonDeath;
        PlayerControllerScript.instance.playerScoreText.text = PlayerPrefs.GetInt("Score", GameManager.instance.PlayerScore).ToString();

        if (GameManager.instance.shieldScoreCounter  >=7000)
        {
            PlayerControllerScript.instance.shieldCounter = 2;
            PlayerControllerScript.instance.shieldImage.SetActive(true);
            PlayerControllerScript.instance.shieldEnabled = true;
            GameManager.instance.shieldScoreCounter = 0;
        }

    }





}
