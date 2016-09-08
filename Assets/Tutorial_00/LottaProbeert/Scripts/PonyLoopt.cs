using UnityEngine;
using System.Collections;

public class PonyLoopt : MonoBehaviour {

    public float speedForward;
    public int heightJump;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, speedForward * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0f, heightJump * Time.deltaTime, -5f);
        }
    }

    /*    float NaarVoren (float speedForward)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(0f,1f*Time.deltaTime, 0f);
            }
        }*/
}
