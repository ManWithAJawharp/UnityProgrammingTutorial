using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode lightKey;

    [SerializeField]
    private GameObject lightGroup;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(Input.GetKeyUp(lightKey))
        {
            lightGroup.SetActive(!lightGroup.activeInHierarchy);
        }
	}
}
