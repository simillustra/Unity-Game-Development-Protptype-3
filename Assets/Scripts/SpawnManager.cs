using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;
    public PlayerController playerControllerScript;
    private Vector3 _spwanPos = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpwanObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpwanObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, _spwanPos, obstaclePrefab.transform.rotation);
        }
    }
}
