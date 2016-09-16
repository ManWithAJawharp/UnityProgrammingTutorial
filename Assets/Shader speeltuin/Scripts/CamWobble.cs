using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CamWobble : MonoBehaviour
{
    [SerializeField, Range(0, 3)]
    private float speed;
    [SerializeField, Range(0,5)]
    private float LissajousScale;
    [SerializeField, Range(0, 10)]
    private float fovScale;
    private float waveTime;
    private Vector3 startPosition;
    private float startFov;
    private Camera cam;

    // Use this for initialization
    void Awake()
    {
        startPosition = transform.position;
        waveTime = 0;
        cam = GetComponent<Camera>();
        startFov = cam.fieldOfView;
    }

    void Update()
    {
        waveTime += Time.deltaTime * speed;
        Vector2 coords = MakeLissajousCoords(waveTime, LissajousScale);
        transform.position = new Vector3(coords.x + startPosition.x , startPosition.y, coords.y + startPosition.z);
        transform.LookAt(Vector3.zero);
        cam.fieldOfView = fovScale * -coords.x + startFov;
        //cam.fieldOfView = fovScale * Vector3.Distance(transform.position-startPosition,Vector3.zero) + startFov;
    }

    Vector2 MakeLissajousCoords(float time,float scale)
    {
        // pi/2 = 1.57079632679
        Vector2 coords = new Vector2();
        coords.x = scale * Mathf.Sin(5f * time + 1.57079632679f);
        coords.y = scale * Mathf.Sin(4f * time);
        return coords;
    }
}
