using UnityEngine;
using System.Collections;

public class MonsterFeed : MonoBehaviour {

    public MonsterStats monsterStats;

    public float hunger;
    public float food;

    void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
    }

    void Update ()
    {
        hunger = monsterStats.hunger;

        if (Input.GetKeyDown("s"))
        {
            if (hunger >= 0)
            {
                Debug.Log("Nomnomnom");
                monsterStats.hunger = hunger - food;
            }
            else if (hunger <= 0)
            {
                Debug.Log("Too much food :(");
                monsterStats.hunger = 0;
            }
        }
    }
}
