using UnityEngine;
using System.Collections;

public class MonsterStats : MonoBehaviour
{
    // starting value of stats
    [Range(0.0F, 100.0F)]   public float hungerStart;
    [Range(0.0F, 100.0F)]   public float happyStart;
    [Range(0.0F, 100.0F)]   public float healthStart;
    [Range(0.0F, 100.0F)]   public float tiredStart;
    [Range(0.0F, 100.0F)]   public float ageStart;

    // current value of stats    
    public float hunger = 0;        
    public float happyness = 0;
    public float health = 0;
    public float tiredness = 0;
    public float age = 0;

    public float strenght = 0;
    public float agility = 0;
    public float wisdom = 0;

    // speed at which stats change
    [Range(0.0F, 10.0F)]    public float hungerspeed = 1;
    [Range(0.0F, 10.0F)]    public float happyspeed = 1;
    [Range(0.0F, 10.0F)]    public float healthspeed = 1;
    [Range(0.0F, 10.0F)]    public float tiredspeed = 1;
    [Range(0.0F, 10.0F)]    public float agespeed = 1;

    // limit that decides when monster goes hungry, gets happy or unhappy, healthy or unhealthy, etc.
    [Range(0.0F, 100.0F)]    public float hungryLimit;
    [Range(0.0F, 100.0F)]    public float happyLimit;
    [Range(0.0F, 100.0F)]    public float healthyLimit;
    [Range(0.0F, 100.0F)]    public float tiredLimit;
    [Range(0.0F, 100.0F)]    public float ageLimit;


    // bools that are used to see if monster is hungry, happy, healthy, etc.
    public bool hungryBool;
    public bool happyBool;
    public bool healthyBool;
    public bool tiredBool;
    public bool agedBool;

    // value that stats are changed by
    public float feedAmount = 10;
    public float happyAmount = 25;
    public float healthAmount = 10;
    public float tiredAmount = 25;

    // set stats to correct startup value
    void Start()
    {
        hunger = hungerStart;
        happyness = happyStart;
        health = healthStart;
        tiredness = tiredStart;
        age = ageStart;
    }

    void Update()
    {
        AdaptStats();
        SetStatStates();
    }

    void AdaptStats()
    {
        hunger += Time.deltaTime * hungerspeed;
        happyness -= Time.deltaTime * happyspeed;
        health -= Time.deltaTime * healthspeed;
        tiredness += Time.deltaTime * tiredspeed;
        age += Time.deltaTime * agespeed;
    }

    void SetStatStates()
    {
// hungry y/n

        if (hunger >= hungryLimit)
        {
            hungryBool = true;
        }

        else
        {
            hungryBool = false;
        }

// happy y/n

        if (happyness >= happyLimit)
        {
            happyBool = true;
        }

        else
        {
            happyBool = false;
        }

// healthy y/n

        if (health >= healthyLimit)
        {
            healthyBool = true;
        }

        else
        {
            healthyBool = false;
        }

// tired y/n

        if (tiredness >= tiredLimit)
        {
            tiredBool = true;
        }

        else
        {
            tiredBool = false;
        }

// aged y/n

        if (age >= ageLimit)
        {
            agedBool = true;
        }

        else
        {
            agedBool = false;
        }
    }

// button functionality
    public void Feed()
    {
        hunger = hunger - feedAmount;
    }

    public void Play()
    {
        happyness = happyness + happyAmount;
    }

    public void Bandage()
    {
        health = health + healthAmount;
    }

    public void Bedtime()
    {
        tiredness = tiredness - tiredAmount;
        // should become a sleeping state in which tiredness is reduced over time
    }
}

