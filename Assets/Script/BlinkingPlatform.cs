using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatform : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxcollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
        
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            boxcollider.enabled = !boxcollider.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
