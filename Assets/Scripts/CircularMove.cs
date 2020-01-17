using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMove : MonoBehaviour
{

    public float radius;
    private Vector3 xAxis;
    public float theta;
    public float speed;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        // Pickup rotates inside of xz plane. x = r sin(theta), z = r cos(theta)
        xAxis = new Vector3(1, 0, 0);
        theta = 0;
        if(direction >= 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Don't need to know current position to calculate next position, we just keep increasing theta and converting to xz coordinates.
        theta += .01f * speed * direction;
        float x = radius * Mathf.Sin(theta);
        float z = radius * Mathf.Cos(theta);
        transform.position = new Vector3(x, transform.position.y, z);
        
    }
}
