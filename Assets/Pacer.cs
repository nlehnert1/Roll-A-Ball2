using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : MonoBehaviour
{

    public float speed = 5.0f;
    private float zMax = 7.5f;
    private float zMin = -7.5f;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zNew = transform.position.z + direction * speed * Time.deltaTime;
    }
}
