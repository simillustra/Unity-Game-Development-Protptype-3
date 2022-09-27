using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private float leftBound = -15;

    private PlayerController _playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Stops Spwaning if  its game over
        if(_playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Destroy obstacles that exit bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
