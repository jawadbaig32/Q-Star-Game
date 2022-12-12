using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawning : MonoBehaviour
{
    public static EnemySpawning instance;
    public GameObject[] objectToSpawn;
    public Vector3 spawnPosition;
    public List<GameObject> spawnedObjList;
    
    Vector3 spawnRotation;
    public bool IsGameover;
    public Transform lookAttarget;



    private void Start()
    {
        StartCoroutine(InstantiateDelay());
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
        float radius = 12f;
        float angle = Random.Range(0, 360);
        spawnPosition.x = (radius * Mathf.Cos(angle)) + centerPosition.x;
        spawnPosition.y = 0;
        spawnPosition.z = (radius * Mathf.Sin(angle)) + centerPosition.z +4f;
       // StartCoroutine(InstantiateDelay());
    }

    public float spawnInterval=4f;

    public void DecreaseSpawnInterval()
    {
        if(spawnInterval>1f)
        {
            spawnInterval -= 0.01f;
        }
    }


    // DELAY in Spawn
    IEnumerator InstantiateDelay()
    {
        while(!IsGameover)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomNum = Random.Range(0, 3);
            GameObject b = Instantiate(objectToSpawn[randomNum], spawnPosition, Quaternion.identity);
            Vector3 direction = lookAttarget.position - b.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            b.transform.rotation = rotation;
        }
    }

    




}
