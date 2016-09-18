using UnityEngine;

public class EyeTracker : MonoBehaviour
{
	void Update ()
    {
        Quaternion lookatRotation = Quaternion.LookRotation(Camera.main.transform.position);
        //lookatRotation.eulerAngles += new Vector3(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookatRotation, Time.deltaTime*4);
	}
}
