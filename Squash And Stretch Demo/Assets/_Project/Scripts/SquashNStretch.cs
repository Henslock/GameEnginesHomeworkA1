using UnityEngine;
using System.Collections;

public class SquashNStretch : MonoBehaviour
{
    /*
    Squash and Stretch - Scale between 0 and 3
    Parent the script to a game object handle with a normalized scale.

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */

    public float Factor = 1.0f;
    public float InfluenceModifier = 1.0f; //Strengthens the volume expansion or compression based on the factor.

	void Start ()
    {
        float divideFactor = (2.0f / InfluenceModifier);
        if(InfluenceModifier==0) { divideFactor = 1; };

        float modVal = (1.0f - ((Factor - 1.0f)/(divideFactor)));

        transform.localScale = new Vector3(
            transform.localScale.x * modVal,
            transform.localScale.y * Factor,
            transform.localScale.z * modVal);
    }

}
