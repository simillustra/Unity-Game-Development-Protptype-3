using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private Vector3 _startPos;

    private float _repeatWith;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWith)
        {
            transform.position = _startPos;
        }
        
    }
}
