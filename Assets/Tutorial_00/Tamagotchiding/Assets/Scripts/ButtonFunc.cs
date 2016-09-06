using UnityEngine;
using System.Collections;

public class ButtonFunc : MonoBehaviour {

    public MonsterStats monsterStats;

    public float hunger;
    public float happyness;
    public float health;
    public float tiredness;
    public float age;

    public float feedAmount = 10;

    void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
    }

    void Update()
    {
        hunger = monsterStats.hunger;
        happyness = monsterStats.happyness;
        health = monsterStats.health;
        tiredness = monsterStats.tiredness;
    }

    public void Feed ()
    {
        hunger = hunger - feedAmount;
	}

}
