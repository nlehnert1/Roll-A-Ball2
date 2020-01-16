using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeTeleporter : MonoBehaviour
{

    float zMax = 15.0f, xMax = 15.0f;
    float zOffset = 7.5f, xOffset = 7.5f;
    private System.Random random;
    private Transform GOTransform;
    private bool findingNewLocation;
    Material material;

    private void Start()
    {
        random = new System.Random();
        findingNewLocation = false;
        material = gameObject.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!findingNewLocation)
        {
            StartCoroutine(TeleportToNewLocation());
        }
    }

    /*IEnumerator Fade()
    {
        for(float fadeTime = 1f; fadeTime >= 0; fadeTime -= 0.1f)
        {
            material.color.a = fadeTime; 
        }
    }*/

    IEnumerator TeleportToNewLocation()
    {
        findingNewLocation = true;
        yield return new WaitForSeconds(3.0f);
        float newX = float.Parse(random.NextDouble().ToString());
        float newZ = float.Parse(random.NextDouble().ToString());
        Vector3 newTransform = new Vector3(newX * xMax - xOffset, transform.position.y, newZ * xMax - xOffset);
        //StartCoroutine(Fade());
        transform.position = newTransform;
        findingNewLocation = false;
    }
}
