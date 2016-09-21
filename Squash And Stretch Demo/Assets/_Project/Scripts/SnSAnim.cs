using UnityEngine;
using System.Collections;

public class SnSAnim : MonoBehaviour
{
    /*
    Squash and Stretch Animation - Manual keyframes with destination models and LERP

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */

    private float t;
    private int keyframe;
    public float Speed = 0.3f;
    public float jumpHeight = 0.5f;
    public float SquishFactor = 1.0f;

    Vector3 m1 = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 m2;
    Vector3 m3;

    private Vector3 p1;
    private Vector3 p2;

    void Start()
    {
        t = 0.0f;
        keyframe = 0;

        p1 = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        p2 = new Vector3(transform.localPosition.x, transform.localPosition.y + jumpHeight, transform.localPosition.z);

        m2 = new Vector3(1.1f * SquishFactor, 0.9f / SquishFactor, 1.1f *SquishFactor);
        m3 = new Vector3(0.9f / SquishFactor, 1.1f * SquishFactor, 0.9f / SquishFactor);
    }

    void Update()
    {   
        t += Time.deltaTime;
        if (keyframe == 0)
        {
            transform.localScale = Vector3.Lerp(m1, m2, t / Speed);
        }
        if (keyframe == 1)
        {
            transform.localScale = Vector3.Lerp(m2, m1, t / Speed);
        }
        if (keyframe == 2)
        {
            transform.localPosition = Vector3.Lerp(p1, p2, t / Speed);
            transform.localScale = Vector3.Lerp(m1, m3, t / Speed);
        }
        if (keyframe == 3)
        {
            transform.localPosition = Vector3.Lerp(p2, p1, t / Speed);
            transform.localScale = Vector3.Lerp(m3, m1, t / Speed);
        }

        if (t >= Speed)
        {
            keyframe++;
            t = 0.0f;
            if(keyframe == 4) { keyframe = 0; } //Let it loop
        }
    }
}
