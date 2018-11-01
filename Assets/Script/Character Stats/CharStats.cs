using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

    int health = 10, energy=10, strength=10, defense=10, speed=10, wisdom=10;
    bool alive = true;

    void deadcheck()
    {
        if (health <= 0)
        {
            alive = false;
        }
    }
}
