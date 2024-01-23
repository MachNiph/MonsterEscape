using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           
            Enemy collidedEnemy = collision.GetComponent<Enemy>();

            
            // Change the direction of the collided enemy
            if (collidedEnemy != null)
            {
                collidedEnemy.Turn();
            }
        }

        if(collision.CompareTag("Player"))
        {
            NewBehaviourScript collidedPlayer = collision.GetComponent<NewBehaviourScript>();

            if(collidedPlayer !=null)
            {
                collidedPlayer.HandlePlayerDeath();
            }
        }

        

    }
}

