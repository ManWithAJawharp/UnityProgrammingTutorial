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
    private KeyCode spawnKey;


    [SerializeField]
    private GameObject lightGroup;
    [SerializeField]
    private GameObject sceneryGroup;
    [SerializeField]
    private Animation turntableAnimation;
    [SerializeField]
    private GameObject spawnable;

	void Update ()
    {
        if (Input.GetKeyUp(spawnKey))
        {
            GameObject pot = Instantiate(spawnable, Vector3.up*5, Quaternion.identity) as GameObject;
            pot.GetComponent<Rigidbody>().AddForceAtPosition(Random.insideUnitSphere, pot.transform.position);
            pot.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Random.Range(1, 100);
        }
        if (Input.GetKeyUp(lightKey))
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
