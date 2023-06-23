using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private float maxRepeatRate = 1f;
    void Start()
    {
        //  InvokeRepeating spawn olma olay�n� belli aral�klar ile yapmam�z� sa�l�yorr.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        // repeatRate de�i�keninin maksimum de�eri kontrol ediliyor
        if (repeatRate > maxRepeatRate)
        {
            repeatRate -= Time.deltaTime / 10; // Her saniye 1/10 oran�nda art�yor
        }
        else
        {
            repeatRate = maxRepeatRate; // Maksimum de�ere ula��nca art�� durduruluyor
        }
    }
    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
        Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
        }
    }
}
