using UnityEngine;
using System.Collections;

public class CubeTrick : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    [SerializeField]
    private Color[] colorArray = { Color.red, Color.green, Color.blue };

    private Renderer renderer;

    void Awake ()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += 0.5f * Time.deltaTime * Vector3.up;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
           renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        else if (Input.GetKey(KeyCode.B))
        {
            renderer.material.color = Color.black;
        }
    }
}
