using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawning : MonoBehaviour
{
    public static EnemySpawning instance;
    public GameObject[] objectToSpawn;
    Vector3 spawnPosition;
    public List<GameObject> spawnedObjList;
    Vector3 spawnRotation;

    public Transform lookAttarget;



    private void Start()
    {
        spawnRotation = transform.eulerAngles;
        lookAttarget = PlayerControllerScript.instance.transform;
       
    }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        SpawnCircleFormation();
    }





    // Create Spawning Orbit
    private void SpawnCircleFormation()
    {
        Vector3 centerPosition = new Vector3(0, 0, 0);
        float radius = 10f;
        float angle = Random.Range(0, 360);

        spawnPosition.x = (radius * Mathf.Cos(angle)) + centerPosition.x;
        spawnPosition.y = 0;
        spawnPosition.z = (radius * Mathf.Sin(angle)) + centerPosition.z +4f;



        StartCoroutine(InstantiateDelay());

    }
   

    // DELAY in Spawn
    IEnumerator InstantiateDelay()
    {
        float t = Random.Range(2, 5);
        yield return new WaitForSeconds(t);

        if (spawnedObjList.Count < 2)
        {
            int randomNum = Random.Range(0, 3);
            GameObject b = Instantiate(objectToSpawn[randomNum], spawnPosition, Quaternion.identity);
            Vector3 direction = lookAttarget.position - b.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            b.transform.rotation = rotation;
            spawnedObjList.Add(b);
        }
    }

}
