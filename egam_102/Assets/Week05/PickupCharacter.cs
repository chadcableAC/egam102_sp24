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
            moveHandle.position += (Vector3) moveDirection.normalized * moveSpeed * Time.deltaTime;
        }

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

    public void OrganizePickups()
    {
        Vector3 originPosition = holdHandle.position;
        for (int i = 0; i < pickupList.Count; i++)
        {
            Vector3 offset = Vector3.up * holdDistance * i;
            pickupList[i].moveHandle.position = originPosition + offset;
        }
    }

    public void DropTop()
    {
        if (pickupList.Count > 0)
        {
            int lastIndex = pickupList.Count - 1;
            pickupList[lastIndex].Reset();
            pickupList.RemoveAt(lastIndex);
        }
    }

    public void DropAll()
    {
        foreach (Pickup pickup in pickupList)
        {
            pickup.Reset();
        }

        pickupList.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup pickup = collision.gameObject.GetComponent<Pickup>();
        if (pickup != null)
        {
            if (pickupList.Contains(pickup) == false)
            {
                pickupList.Add(pickup);
            }
        }
    }
}
