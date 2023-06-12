using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Hp_Manager 
{

    public Transform m_SpawnPoint;                          // The position and direction the Battery will have when it spawns.
    [HideInInspector] public GameObject m_Instance;         // A reference to the instance of the Battery when it is created.

    private Rotation_Monement m_Movement ;        // Access to movement script to disable / enable
    private Healing m_Health ;                    // Access to healing script to disable / enable
    private float timer = 0f;





    //Used to get a hold of the Script components and to bee able to enable / disable them
    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<Rotation_Monement>();
        m_Health   = m_Instance.GetComponent<Healing>();
    }

    // Used during the end of a round so that players won 't be able to use the health-pack and to stop its animation.
    public void Disable()
    {
        m_Movement.enabled = false ;
        m_Health.enabled   = false ;

        m_Instance.SetActive(false);
    }

    // Used during the phases of the game where the player should be able to use the health-pack.
    public void Enable()
    {
        m_Movement.enabled = true ;
        m_Health.enabled   = true ;

        m_Instance.SetActive(true);
    }
    

    public void Reset()           // Used at the start of each round to put the Healthpack into it's default state.
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }

    public void Respawn()         
    {
        if(m_Health.m_colission)        // Dispawns object
        {
            m_Instance.SetActive(false);
            m_Health.m_colission = false ;
        }

      if(!m_Instance.activeSelf)
        {
            timer += Time.deltaTime;    // Increaments timer ...
            
            if(timer>=8f)
            {
                // ... and respawns object after 8 seconds

                Reset() ;      
                timer =0f ;
            }

        }
    }


    
}
