﻿using System.Collections;
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
    /// 
    /// </summary>
    /// <param name="targetMaterial"></param>
    /// <param name="startingOpacity"></param>
    /// <param name="targetOpacity"></param>
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
        StartCoroutine(FadeTo(material, 1, 0, 1.0f));            
        while (fadingOut)
        {
            yield return null;
        }

        if (isParent)
        {
            float newX = float.Parse(random.NextDouble().ToString());
            float newZ = float.Parse(random.NextDouble().ToString());
            newTransform = new Vector3(newX * xMax - xOffset, transform.position.y, newZ * xMax - xOffset);
            transform.position = newTransform;
        }


        StartCoroutine(FadeTo(material, 0, 1, 1.0f));
        while (fadingIn)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        findingNewLocation = false;
    }
}
