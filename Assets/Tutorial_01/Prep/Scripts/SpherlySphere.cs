using UnityEngine;
using System.Collections;

public class SpherlySphere : MonoBehaviour
{
    //  Declare Transform array, denoted by []
    private Transform[] children;
    public int experimenteren;
    protected void Awake ()
    {

        //  Fill the array using a built-in function
        children = GetComponentsInChildren<Transform>();
    }

    protected void Update ()
    {
        //  children[0] is this object
        children[1].position += Time.deltaTime * Mathf.Sin(Time.time) * new Vector3(-1f, 0.5f, 0.5f);
        for (int i = 2; i < children.Length; i++)
        {
            children[i].position += Time.deltaTime * Mathf.Sin(Time.time + i * experimenteren) * new Vector3(transform.position.x + Mathf.Sin(i*2), transform.position.x * Mathf.Sin(i*3), transform.position.x - Mathf.Sin(i));
        }
    }
}
