using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private List<Color> rainbow = new List<Color> { Color.red, Color.yellow, Color.green, Color.blue };
    private int currColorIndex = 0;
    private int nextColorIndex = 1;
    private bool startedColorShift = false;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material.color = rainbow[currColorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, rainbow[nextColorIndex], 0.01f);
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            time = 0f;
            nextColorIndex++;
            if(nextColorIndex > 3)
            {
                nextColorIndex = 0;
            }
        }
    }
}
