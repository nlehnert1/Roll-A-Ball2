﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 40, 35) * Time.deltaTime);
    }

    private void ApplyDamage()
    {
        gameObject.SetActive(false);
    }
}
