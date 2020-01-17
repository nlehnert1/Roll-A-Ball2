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
    MeshRenderer meshRenderer;
    MeshRenderer childRenderer;
    Material material;
    Material childMaterial;
    bool isParent;
    bool fadingIn;
    bool fadingOut;

    private void Start()
    {
        random = new System.Random();
        findingNewLocation = false;
        fadingIn = false;
        fadingOut = false;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        //childRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        material = meshRenderer.material;
        //childMaterial = childRenderer.material;
        isParent = gameObject.CompareTag("Pick Up Special");
    }

    // Update is called once per frame
    void Update()
    {

        if (!findingNewLocation)
        {
            //StartCoroutine(FadeTo(material, 1, 0, 1.0f));
            StartCoroutine(TeleportToNewLocation());
            //StartCoroutine(FadeTo(material, 0, 1, 1.0f));
        }
    }

    /// <summary>
    /// After waiting for waitTime, causes the color of the provided material to fade from starting opacity to target opacity over a specified duration;
    /// </summary>
    /// <param name="opacity"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator FadeTo(Material targetMaterial, float startingOpacity, float targetOpacity, float duration)
    {
        fadingOut = targetOpacity == 0;
        fadingIn = targetOpacity == 0;

        float t = 0;

        while(t < duration)
        {
            t += Time.deltaTime;
            Color c = targetMaterial.color;
            float blendValue = Mathf.Clamp01(t / duration);
            c.a = Mathf.Lerp(startingOpacity, targetOpacity, blendValue);
            targetMaterial.color = c;
            yield return null;
        }
        if (fadingIn) fadingIn = !fadingIn;
        if (fadingOut) fadingOut = !fadingOut;
    }

    IEnumerator TeleportToNewLocation()
    {
        findingNewLocation = true;
        Vector3 newTransform = new Vector3();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeTo(material, 1, 0, 1.0f));            //These both wait from t=0 to t=2, then run from t=2 to t=2.75
        //StartCoroutine(FadeTo(childMaterial, 1, 0, 2.0f, 0.75f));

        // Pickup is fading out. Don't progress teleportation yet.
        while (fadingOut)
        {
            yield return null;
        }

        //Finished fading out. Wait .25 sec, then continue
        //yield return new WaitForSecondsRealtime(0.25f);
        if (isParent)
        {
            float newX = float.Parse(random.NextDouble().ToString());
            float newZ = float.Parse(random.NextDouble().ToString());
            newTransform = new Vector3(newX * xMax - xOffset, transform.position.y, newZ * xMax - xOffset);
            transform.position = newTransform;
        }


        StartCoroutine(FadeTo(material, 0, 1, 1.0f));             //These SHOULD wait from t=3.5 to t=4, then fade back in from t=4 to t=5
        //StartCoroutine(FadeTo(childMaterial, 0, 1, 0.5f, 1.0f));        
        while (fadingIn)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        findingNewLocation = false;
    }
}
