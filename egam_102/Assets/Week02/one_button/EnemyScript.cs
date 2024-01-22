using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public SpriteRenderer mySprite;

    public Color colorFire;
    public Color colorHit;
    public Color colorReact;

    public bool hasFired;
    public bool hasBeenHit;

    public float fireTimer = 5f;
    public float fireReactTimer = 1f;

    public PlayerScript player;

    // Update is called once per frame
    void Update()
    {
        // Keep counting down on the  timer
        fireTimer -= Time.deltaTime;
        
        // If the timer is below 0, try to fire
        if (fireTimer <= 0)
        {
            // If we have NOT fired AND have NOT been hit, then we can shoot
            if (hasFired == false &&
                hasBeenHit == false)
            {
                Shoot();
                hasFired = true;
            }
        }
        // If the timer is below "react time", switch our color
        else if (fireTimer <= fireReactTimer)
        {
            // If we have NOT been hit, then we can chaneg color
            if (hasBeenHit == false)
            {
                mySprite.color = colorReact;
            }
        }
    }

    void Shoot()
    {
        // Switch our color
        mySprite.color = colorFire;

        // Shoot the player
        player.OnShot();
    }

    public void OnShot()
    {
        // We can only be hit if the timer is in the right range
        // Less than the react time AND more than 0
        if (fireTimer <= fireReactTimer &&
            fireTimer > 0)
        {
            mySprite.color = colorHit;
            hasBeenHit = true;
        }
    }
}
