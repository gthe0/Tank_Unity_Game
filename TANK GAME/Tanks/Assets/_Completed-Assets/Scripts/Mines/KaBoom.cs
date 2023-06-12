using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaBoom : MonoBehaviour
{

     public ParticleSystem m_ExplosionParticles;
     public AudioSource m_ExplosionAudio; 
    public LayerMask m_LayerMask;

     private float SphereRadious = 1.5f ;
     public bool ChangeSpawn = false ; // Used to see if it has spawned in the wrong place.
     public bool Pressed = false ;  // Used to see if instance has collided with tank. 


     public static float Damage = 40f;

    
    private void OnTriggerEnter (Collider other)
    {

        // Find the TankHealth script associated with the rigidbody.
        TankHealth targetHealth = other.GetComponent<TankHealth>();

        targetHealth.TakeDamage(Damage);

        m_ExplosionAudio.transform.parent = null ;

        m_ExplosionParticles.transform.parent = null ;

            m_ExplosionAudio.Play();
            m_ExplosionParticles.Play();
                
        Pressed = true ;    // The trap was pressed
    }

    public void Wrong_Spawn()
    {
       ChangeSpawn = Physics.CheckSphere(transform.position,SphereRadious,m_LayerMask);     // Checks if there are other objects nearby. 
    }
    



    }

