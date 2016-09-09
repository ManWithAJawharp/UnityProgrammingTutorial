using UnityEngine;
using System.Collections;

public class SwerlyLerp : MonoBehaviour
{
    [SerializeField]
    private Vector3 start;
    [SerializeField]
    private Vector3 end;

    private float time = 0.0f;

    protected void Update ()
    {
        transform.position = Lerp(start, end, time);

        //  Make t loop from 0 to 1 over the course of one second
        if (time < 1f)
            time += Time.deltaTime;
        else
            time = 0f;
    }

    protected Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return (1f - t) * start + t * end   //  Standard Lerp
            + Mathf.Sin(2 * Mathf.PI * t) * Vector3.up //  Add wave movement along y-axis
            + 2 * Mathf.Pow(2 * t - 1, 2) * Vector3.forward;    //  Add parabolic movement along z-axis
    }
}
