using UnityEngine;
using System.Collections;

public class PonyLoopt : MonoBehaviour {

    public float speedForward;
    public int heightJump;
    public int speedJump;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, speedForward * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position.y <= heightJump)
            {
                transform.Translate(0f, speedJump * Time.deltaTime, 0f);
            }
        }
    }
    
    protected Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return (1f - t) * a + t * b   //  Standard Lerp
            + Mathf.Sin(2 * Mathf.PI * t) * Vector3.up //  Add wave movement along y-axis
            + 2 * Mathf.Pow(2 * t - 1, 2) * Vector3.forward;    //  Add parabolic movement along z-axis
    }
    

    //while hoogte < heightJump translate y met speedJump

    /*  if (someObject.transform.position.x == someX)
        {
             do something
        }
     *    
     *    
     *    
     *    
     *    float NaarVoren (float speedForward)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(0f,1f*Time.deltaTime, 0f);
            }
        }*/
}
