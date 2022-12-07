using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{

    public static PlayerControllerScript instance;
    public FixedJoystick _joyStick;
    public GameObject playerFire;
    public Transform playerFirepos;
    public GameObject playerH_Bar_red;
    public GameObject playerH_Bar_green;
    public GameObject playerH_Bar_yellow;
    public int playerhealth = 3;
    public bool shieldEnabled;
    public int shieldCounter = 2;
    public int shieldScore = 7000;
    public GameObject shieldImage;
    public Text playerScoreText;
    public Vector3 rotateAngle;
    public float speed;
    public bool isJoystick;

 



    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        RotatePlayer();
        BulletSpawn();
        RotateWithKeys();
    }
    private void Start()
    {
        playerScoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }


    // JoyStick Controller
    public void RotatePlayer()
    {



        if (_joyStick.Vertical == 0 || _joyStick.Horizontal == 0)
        {

            isJoystick = false;

        }
            if (isJoystick)
        {
            if (_joyStick.Vertical != 0 || _joyStick.Horizontal != 0)
            {
                this.transform.eulerAngles = new Vector3(0, Mathf.Atan2(_joyStick.Vertical, -_joyStick.Horizontal) * 180 / Mathf.PI, 0);
                this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
            }
        }
    }


    public void RotateWithKeys()
    {
        //Keys

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Horizontal") == 0)
        {

            isJoystick = true;

        }

            if (!isJoystick)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                isJoystick = false;
                transform.Rotate(rotateAngle * speed * Time.deltaTime);

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                isJoystick = false;
                transform.Rotate(rotateAngle * -speed * Time.deltaTime);
            }

        }
     
    }


// Player Fires
public void BulletSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletFire = Instantiate(playerFire, playerFirepos.position, playerFirepos.rotation);
            Destroy(bulletFire, 5);
        }
    }



    // Player Fires with OnScreenBtn
    public void BulletSpawnWithBtn()
    {
            GameObject bulletFire = Instantiate(playerFire, playerFirepos.position, playerFirepos.rotation);
            Destroy(bulletFire, 5);
    }


}



  



