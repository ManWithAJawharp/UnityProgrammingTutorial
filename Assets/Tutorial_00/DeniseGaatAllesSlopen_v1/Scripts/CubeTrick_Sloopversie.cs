using UnityEngine;
using System.Collections;

public class CubeTrick_Sloopversie : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float speedY = 5f;
    [SerializeField, Range(0f, 10f)]
    private float speedX = 6f;
    [SerializeField, Range(0f, 10f)]
    private float speedZ = 3f;

    [SerializeField, Range(0.01f, 5f)]
    private float sinusA;
    [SerializeField, Range(0.01f, 5f)]
    private float sinusB;
    [SerializeField, Range(0f, 5f)]
    private float sinusC;
    [SerializeField, Range(0f, 5f)]
    private float sinusD;

    [SerializeField]
    private Color[] colorArray = { Color.red, Color.green, Color.blue };

    private Renderer renderer;

    public GameObject Sphere;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    float calculateTransformedSine(float value, float a, float b, float c, float d)
    {
        float product;
        product = a * Mathf.Sin((value * b) + c) + d;

        return product;
    }

    void Update()
    {
        // Change color over time with sinoid
        renderer.material.color = new Color(calculateTransformedSine(Time.time * speedX, 0.5f, 1, 0, 0.5f),
            calculateTransformedSine(Time.time * speedY, 0.5f, 1, 0, 0.5f),
            calculateTransformedSine(Time.time * speedZ, 0.5f, 1, 0, 0.5f));

        // Change position over time with sinoid
        transform.position = new Vector3(Mathf.Sin(Time.time * speedX), Mathf.Sin(Time.time * speedY), Mathf.Sin(Time.time * speedZ));
        // Change rotation over time with sinoid
        transform.Rotate(new Vector3(Mathf.Sin(Time.time * speedX), Mathf.Sin(Time.time * speedY), Mathf.Sin(Time.time * speedZ)));
        // Translate scale, but keeps value between 0.3 and 3
        transform.localScale = Vector3.one * calculateTransformedSine(Time.time * speedX, sinusA, sinusB, sinusC, sinusD);


        if (Input.GetKeyDown(KeyCode.Q))
        {
            return;
            // transform.position;
        }
    }
}
