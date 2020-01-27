using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // Move towards player slowly
    }

    private void ApplyDamage()
    {
        gameObject.SetActive(false);
    }
}
