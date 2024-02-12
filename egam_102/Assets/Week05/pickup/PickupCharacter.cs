using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCharacter : MonoBehaviour
{
    public Transform moveHandle;
    public float moveSpeed;

    public Pickup[] pickupArray;
    public List<Pickup> pickupList;

    public Transform holdHandle;
    public float holdDistance;

    void Update()
    {
        UpdateControls();
        OrganizePickups();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DropTop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropAll();
        }
    }

    void UpdateControls()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += Vector2.down;
        }

        if (moveDirection != Vector2.zero)
        {
            moveHandle.position += moveSpeed * Time.deltaTime * (Vector3)moveDirection.normalized;
        }
    }

    public void OrganizePickups()
    {
        // Use this handle as the starting point
        Vector3 originPosition = holdHandle.position;
        for (int i = 0; i < pickupList.Count; i++)
        {
            // Offset per element
            Vector3 offset = holdDistance * i * Vector3.up;

            // Set at the position
            pickupList[i].moveHandle.position = originPosition + offset;
        }
    }

    public void DropTop()
    {
        // Only remove if there's something in the list (more than 0)
        if (pickupList.Count > 0)
        {
            // Lists are "zero based", so the last element is "count minus one"
            int lastIndex = pickupList.Count - 1;
            pickupList[lastIndex].Reset();

            // Remember to remove this entry from the list
            pickupList.RemoveAt(lastIndex);
        }
    }

    public void DropAll()
    {
        // Drop everything in the list
        foreach (Pickup pickup in pickupList)
        {
            pickup.Reset();
        }

        // Clear the list
        pickupList.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Did this collider have a Pickup script on it?
        Pickup pickup = collision.gameObject.GetComponent<Pickup>();
        if (pickup != null)
        {
            // Don't re-add to the list
            if (pickupList.Contains(pickup) == false)
            {
                pickupList.Add(pickup);
            }
        }
    }
}
