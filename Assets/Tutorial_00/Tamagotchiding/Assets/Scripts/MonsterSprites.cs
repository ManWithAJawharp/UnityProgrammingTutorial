using UnityEngine;
using System.Collections;

public class MonsterSprites : MonoBehaviour {

    public MonsterStats monsterStats;


    void Start ()
    {
        monsterStats = GetComponent <MonsterStats> ();
	}

    void Update ()
    {
    }
}
