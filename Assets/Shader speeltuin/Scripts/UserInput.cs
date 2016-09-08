using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode lightKey;
    [SerializeField]
    private KeyCode sceneryKey;
    [SerializeField]
    private KeyCode turntableKey;

    [SerializeField]
    private GameObject lightGroup;
    [SerializeField]
    private GameObject sceneryGroup;
    [SerializeField]
    private Animation turntableAnimation;

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

        if (Input.GetKeyUp(turntableKey))
        {
            if (turntableAnimation.isPlaying)
            {
                turntableAnimation.Stop();
            }
            else
            {
                turntableAnimation.Play();
            }
        }
    }
}
