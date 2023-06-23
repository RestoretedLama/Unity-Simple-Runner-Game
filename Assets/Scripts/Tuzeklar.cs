using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzeklar : MonoBehaviour
{
    private float speed = 10;
    public float maxSpeed = 30;
    public float speedRate = 0.1f;
    private PlayerController playerControllerScript;
    float leftBound = -15;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            if( speed < maxSpeed)
            { 
                speed += speedRate * Time.deltaTime;
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("tuzak"))
        {
            Destroy(gameObject);
        }
    }
}
