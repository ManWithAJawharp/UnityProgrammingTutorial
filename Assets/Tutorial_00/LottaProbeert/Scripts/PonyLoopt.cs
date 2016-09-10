using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PonyLoopt : MonoBehaviour {

    public int speedForward;
    public int heightJump;
    public int speedJump;
    private bool collisionPony;
    private Rigidbody rigidbodyPony;
    private Vector3 beginPositiePony;
    private Quaternion beginRotatiePony;
    
	// Use this for initialization
	void Start () {
        rigidbodyPony = GetComponent<Rigidbody>();
        beginPositiePony = transform.position;
        beginRotatiePony = transform.rotation;
	}

    // Update is called once per frame-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Update () {
        transform.Translate(0f, 0f, speedForward * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && collisionPony == true)
        {
            rigidbodyPony.AddForce(Vector3.up * speedJump, ForceMode.Impulse);
        }
    }
    
    protected Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return (1f - t) * a + t * b   //  Standard Lerp
            + Mathf.Sin(2 * Mathf.PI * t) * Vector3.up //  Add wave movement along y-axis
            + 2 * Mathf.Pow(2 * t - 1, 2) * Vector3.forward;    //  Add parabolic movement along z-axis
    }
    
    //Of ie mag springen ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void OnCollisionEnter(Collision col)
    {
        collisionPony = true;
    }

    void OnCollisionExit(Collision col)
    {
        collisionPony = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //of ie doodgaat------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Respawn")
        {
            transform.position = beginPositiePony;
            transform.rotation = beginRotatiePony;
        }
        else if (col.tag == "Finish")
        {
            //andere scene laden
            SceneManager.LoadScene("StartScenePonie");
        }
    }
}
