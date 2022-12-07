using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    


    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * -speed;
    }



    // Do on Collision
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemiesWhite") )
        {
            other.gameObject.GetComponent<EnemyMovement>().ReceiveDamage(1);
            Destroy(this.gameObject);
        }
       else if (other.gameObject.CompareTag("EnemiesGreen") )
        {
            other.gameObject.GetComponent<EnemyMovement>().ReceiveDamage(1);
            Destroy(this.gameObject);

        }
      else  if (other.gameObject.CompareTag("EnemiesOrange") )
        {
            other.gameObject.GetComponent<EnemyMovement>().ReceiveDamage(1);
            Destroy(this.gameObject);
        }
    }
}
