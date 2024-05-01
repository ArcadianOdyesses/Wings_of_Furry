using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalParallaxBackground : MonoBehaviour
{
    private float length, startpos;
    public GameObject player;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        float temp = (player.transform.position.y * (1 - parallaxEffect));
        float dist = (player.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
