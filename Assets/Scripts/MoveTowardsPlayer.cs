using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MoveTowardsPlayer : MonoBehaviour
{
    public AudioSource deathSound;

    public Transform playerTransform;
    private float speed = .05f;

    private void Start()
    {
        deathSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player slowly
        this.transform.Translate(((playerTransform.position + new Vector3(0f, 0.5f, 0f)) - transform.position) * speed * Time.deltaTime);
    }

    private void ApplyDamage()
    {
        deathSound.Play();
        gameObject.SetActive(false);
    }
}

