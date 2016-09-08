﻿using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode lightKey;
    [SerializeField]
    private KeyCode sceneryKey;

    [SerializeField]
    private GameObject lightGroup;
    [SerializeField]
    private GameObject sceneryGroup;

	void Update ()
    {
	    if(Input.GetKeyUp(lightKey))
        {
            lightGroup.SetActive(!lightGroup.activeInHierarchy);
        }

        if (Input.GetKeyUp(sceneryKey))
        {
            sceneryGroup.SetActive(!sceneryGroup.activeInHierarchy);
        }
    }
}
