using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class TrapManager 
{
    [HideInInspector] public GameObject m_Instance;         // A reference to the instance of the trap  when it is created.

    private KaBoom m_Kaboom ;                // Used to check if instance was pressed and to reset particles and audio
    

    public bool ChangeSpawn ; 

    public void Setup()
    {
        m_Kaboom = m_Instance.GetComponent<KaBoom>();
    }

    public void Des_instance()      
    {
        if(m_Kaboom.Pressed) // If ther trap is pressed hide it.
        {
            if(m_Instance.activeSelf)
            {
               m_Instance.SetActive(false);

               m_Kaboom.Pressed = false ;
            }
        }
    }

    public void Deactivate()
    {
        if(m_Kaboom.Pressed)
        {           
            m_Instance.SetActive(false) ;
        }
    }

    public void Collision()
    {
        m_Kaboom.Wrong_Spawn();

        ChangeSpawn = m_Kaboom.ChangeSpawn ;

    }

    public void ParticleReposition(Vector3 pos)
    {

        m_Kaboom.m_ExplosionAudio.transform.position = pos ;
        m_Kaboom.m_ExplosionParticles.transform.position = pos ;

    }

}
