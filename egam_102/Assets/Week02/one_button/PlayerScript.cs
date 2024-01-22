using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer mySprite;

    public Color colorFire;
    public Color colorHit;

    public bool hasFired;
    public bool hasBeenHit;

    public EnemyScript enemy;

    // Update is called once per frame
    void Update()
    {
        // If LMB, space, OR return is pressed, try to fire
        if (Input.GetMouseButtonDown(0) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return))
        {
            // If we have NOT fired AND have NOT been hit, then we can shoot
            if (hasFired == false &&
                hasBeenHit == false)
            {
                Shoot();
                hasFired = true;
            }
        }
    }

    void Shoot()
    {
        // Change our color
        mySprite.color = colorFire;

        // Try to shoot the enemy
        enemy.OnShot();
    }

    public void OnShot()
    {
        // Switch our color
        mySprite.color = colorHit;
        hasBeenHit = true;
    }
}
