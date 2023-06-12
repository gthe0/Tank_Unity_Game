using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCheat : MonoBehaviour
{

    public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.

    string[] CheatInvincible ;                  // Cheatsheet for invincibility.
    string[] CheatDoubleDmg ;                   // Cheatsheet to make the enemy tank take double the amount of damage.
    string[] CheatStopMovement;                 // Cheatsheet to freeze enemy tank.
    string[] CheatStopShooting;                 // Cheatsheet to make enemy tank stop shooting.

    private TankHealth m_TankHP ; 


    public int m_Index_Invincible = 0 ;        // Indexes used to count the correct inputs of each cheatsheet.
    public int m_Index_DoubleDmg = 0 ; 
    public int m_Index_StopMovement = 0 ; 
    public int m_Index_StopShooting = 0 ;

    public bool m_DoubleDamage = false ;        // Used to make the enemy player take double dmg.
    public bool m_Freeze = false ;          // Used to make the enemy freeze.
    public bool m_Pacify = false ;          // USed to make the enemy sto shooting.

    private KeyCode Left , Right , Up , Down ,Shoots ;

    // Start is called before the first frame update.
    void Start()
    {
        // Based on the player's number Initialize each cheatsheet for the duration of the game.
        if(m_PlayerNumber == 1)
        {
            CheatInvincible = new string[]{"a" , "a", "w" , "s", "w"};
            CheatDoubleDmg  = new string[]{"d" , "d",  "s" , "w", "s"};
            CheatStopMovement  = new string[]{"w" , "w",  "a" , "d", "a"};
            CheatStopShooting  = new string[]{"a" , "w",  "s" , "s", "a"};
        
        Left  = KeyCode.A ;
        Up    = KeyCode.W ; 
        Down  = KeyCode.S ; 
        Right = KeyCode.D ;
        Shoots= KeyCode.Space;
        }
        else if(m_PlayerNumber == 2)
        {
            CheatInvincible = new string[]{"left" , "left", "up" , "down", "up"};
            CheatDoubleDmg  = new string[]{"right" , "right",  "down" , "up", "down"};
            CheatStopMovement  = new string[]{"up" , "up", "left" , "right", "left"};
            CheatStopShooting  = new string[]{"left" , "up",  "down" , "down", "left"};
        
        Left  = KeyCode.LeftArrow ;
        Up    = KeyCode.UpArrow ; 
        Down  = KeyCode.DownArrow ; 
        Right = KeyCode.RightArrow ;
        Shoots= KeyCode.Return;
            
        }


        m_TankHP = gameObject.GetComponent<TankHealth>();

    }

    // Update is called once per frame.
    void Update()
    {
        if(Input.GetKeyDown(Left) ||Input.GetKeyDown(Right) ||Input.GetKeyDown(Up) ||Input.GetKeyDown(Down) ||Input.GetKeyDown(Shoots) )
        {    
        Invincible();
        DoubleDmg();
        StopMovement();
        StopShooting();
        }
    }

    void Invincible()       
    {

        if(Input.GetKeyDown(CheatInvincible[m_Index_Invincible]))
        {
            m_Index_Invincible ++ ;     // If input is correct increment index by 1.
        }
        else m_Index_Invincible = 0 ;   // else reset it to 0.

        if(m_Index_Invincible == CheatInvincible.Length)
        {
            m_TankHP.m_Invincible = true ;      // If done correctly make the player invincible.
            m_Index_Invincible = 0 ; 
        }
        
    }

    void DoubleDmg()       
    {

        if(Input.GetKeyDown(CheatDoubleDmg[m_Index_DoubleDmg]))
        {
            m_Index_DoubleDmg ++ ;     // If input is correct increment index by 1.
        }
        else m_Index_DoubleDmg = 0 ;   // else reset it to 0.

        if(m_Index_DoubleDmg == CheatDoubleDmg.Length)
        {
           m_DoubleDamage = true ;      // If done correctly make the enemy player take double dmg.
           m_Index_DoubleDmg = 0 ;
        }
        
    }

    void StopMovement()       
    {

        if(Input.GetKeyDown(CheatStopMovement[m_Index_StopMovement]))
        {
            m_Index_StopMovement ++ ;     // If input is correct increment index by 1.
        }
        else m_Index_StopMovement = 0 ;   // else reset it to 0.

        if(m_Index_StopMovement == CheatStopMovement.Length)
        {
           m_Freeze = true ;      // If done correctly make the enemy player freeze.
           m_Index_StopMovement = 0 ;
        }
        
    }

    void StopShooting()       
    {

        if(Input.GetKeyDown(CheatStopShooting[m_Index_StopShooting]))
        {
            m_Index_StopShooting ++ ;     // If input is correct increment index by 1.
        }
        else m_Index_StopShooting = 0 ;   // else reset it to 0.

        if(m_Index_StopShooting == CheatStopShooting.Length)
        {
           m_Pacify = true ;      // If done correctly make the enemy a Pacifist.
           m_Index_StopShooting = 0 ;
        }
    }



}
