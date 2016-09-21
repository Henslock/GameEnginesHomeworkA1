using UnityEngine;
using System.Collections;

public class SnSAnim : MonoBehaviour
{
    /*
    Squash and Stretch Animation - Manual keyframes with destination models and LERP

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */

    public float t;
    private int keyframe;
    private float duration = 0.3f;
    private bool flip = false;

    Vector3 m1 = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 m2 = new Vector3(1.1f, 0.9f, 1.1f);
    Vector3 m3 = new Vector3(0.9f, 1.1f, 0.9f);
    private float jumpHeight = 0.5f;
    private Vector3 p1;
    private Vector3 p2;

    void Start()
    {
        t = 0.0f;
        keyframe = 0;
        p1 = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        p2 = new Vector3(transform.localPosition.x, transform.localPosition.y + jumpHeight, transform.localPosition.z);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (keyframe == 0)
        {
            transform.localScale = Vector3.Lerp(m1, m2, t / duration);
        }
        if (keyframe == 1)
        {
            transform.localScale = Vector3.Lerp(m2, m1, t / duration);
        }
        if (keyframe == 2)
        {
            transform.localPosition = Vector3.Lerp(p1, p2, t / duration);
            transform.localScale = Vector3.Lerp(m1, m3, t / duration);
        }
        if (keyframe == 3)
        {
            transform.localPosition = Vector3.Lerp(p2, p1, t / duration);
            transform.localScale = Vector3.Lerp(m3, m1, t / duration);
        }

        if (t >= duration)
        {
            keyframe++;
            t = 0.0f;
            if(keyframe == 4) { keyframe = 0; } //Let it loop
        }
    }
}
