using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float demage)
    {
        hitPoints -= demage;
        if (hitPoints <= 0)
        {
            // Debug.Log("You are dead :(");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
