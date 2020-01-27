using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    public Transform playerTransform;
    private float speed = .05f;

    // Update is called once per frame
    void Update()
    {
        // Move towards player slowly
        this.transform.Translate(((playerTransform.position + new Vector3(0f,0.5f,0f)) - transform.position) * speed * Time.deltaTime);
    }

    private void ApplyDamage()
    {
        gameObject.SetActive(false);
    }
}
