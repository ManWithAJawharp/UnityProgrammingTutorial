using UnityEngine;
using System.Collections;

public class SpherlySphere : MonoBehaviour
{
    //  Declare Transform array, denoted by []
    private Transform[] children;

    protected void Awake ()
    {
        //  Fill the array using a built-in function
        children = GetComponentsInChildren<Transform>();
    }

    protected void Update ()
    {
        //  children[0] is this object
        children[1].position += Time.deltaTime * Mathf.Sin(Time.time) * Vector3.up;
        children[2].position += Time.deltaTime * Mathf.Sin(Time.time) * Vector3.up;
        children[3].position += Time.deltaTime * Mathf.Sin(Time.time) * Vector3.up;
    }
}
