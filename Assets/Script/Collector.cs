using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            Enemy collidedEnemy = collision.gameObject.GetComponent<Enemy>();


            // Change the direction of the collided enemy
            if (collidedEnemy != null)
            {
                collidedEnemy.Turn();
            }
        }

        

    }
}

