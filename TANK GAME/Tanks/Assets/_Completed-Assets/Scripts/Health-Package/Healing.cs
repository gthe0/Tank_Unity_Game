using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float m_healing = 40f;               // The amount of health restored on trigger.
    public bool m_colission = false ;           // Variable to check collision (Used to Dispawn object)
   
    private void OnTriggerEnter(Collider other) 
    {

        // Find the TankHealth script associated with the rigidbody.
        TankHealth targetHealth = other.GetComponent<TankHealth>();

        // If there is no TankHealth script attached to the gameobject, go on to the next collider.
        if (!targetHealth)
            return;

        // If the Tank 's health is full do nothing
        if (targetHealth.GetHealth() == targetHealth.m_StartingHealth)
            return;

        targetHealth.HealDamage(m_healing); //Heals the tank and dispawns object
        
        // It colided with a tank not fully healed.
        m_colission = true ;
       // gameObject.SetActive(false);    
    }
}
