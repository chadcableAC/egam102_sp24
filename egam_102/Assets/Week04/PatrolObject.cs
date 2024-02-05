using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolObject : MonoBehaviour
{
    public Transform moveHandle;

    public enum PatrolStates
    {
        Patrol,     // 0
        Chase,      // 1
        RunAway,    // 2
        Idle        // 3
    }

    PatrolStates previousState;
    public PatrolStates currentState;

    // Patrol variables
    public Transform patrolHandleA;
    public Transform patrolHandleB;
    Transform patrolTarget;

    public float minimumDistance;

    public float minimumEnemyDistance = 1f;

    // Run away / chase variables
    public Transform enemyHandle;
    public float moveSpeed;

    private void Start()
    {
        patrolTarget = patrolHandleA;
    }

    void Update()
    {
        if (currentState != previousState)
        {
            switch (currentState)
            {

            }

            previousState = currentState;
        }


        // Based on teh current state, redierect to that Update loop
        switch (currentState)
        {
            case PatrolStates.Patrol:
                UpdatePatrol();
                break;

            case PatrolStates.Idle:
                UpdateIdle();
                break;

            case PatrolStates.Chase:
                UpdateChase();
                break;

            case PatrolStates.RunAway:
                UpdateRunAway();
                break;
        }

        // This is the SAME as the above "switch" statement,
        // But with if elses
        //if (currentState == PatrolStates.Patrol)
        //{
        //    UpdatePatrol();
        //}
        //if (currentState == PatrolStates.Idle)
        //{
        //    UpdateIdle();
        //}
        //if (currentState == PatrolStates.Chase)
        //{
        //    UpdateChase();
        //}
        //if (currentState == PatrolStates.RunAway)
        //{
        //    UpdateRunAway();
        //}
    }

    public void SetState(PatrolStates newState)
    {
        currentState = newState;
        switch (currentState)
        {

        }
    }

    public void UpdatePatrol()
    {
        // Move towards this position
        Vector3 targetPosition = patrolTarget.position;

        // To find the diurection from A to B = B - A
        Vector3 delta = targetPosition - moveHandle.position;
        Vector3 moveDirection = delta.normalized;

        moveHandle.position += moveDirection * moveSpeed * Time.deltaTime;

        // If we're REALLY close, change our target
        if (delta.magnitude < minimumDistance)
        {
            if (patrolTarget == patrolHandleA)
            {
                patrolTarget = patrolHandleB;
            }
            else
            {
                patrolTarget = patrolHandleA;
            }
        }

        // Are we close to the enemy?
        Vector3 enemyPosition = enemyHandle.position;
        Vector3 enemyDelta = enemyPosition - moveHandle.position;
        if (enemyDelta.magnitude < minimumEnemyDistance)
        {
            // We're really close to the enemy - start chasing!
            SetState(PatrolStates.Chase);
        }
    }

    public void UpdateChase()
    {
        // Move towards this position
        Vector3 targetPosition = enemyHandle.position;

        // To find the diurection from A to B = B - A
        Vector3 delta = targetPosition - moveHandle.position;
        Vector3 moveDirection = delta.normalized;

        moveHandle.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void UpdateRunAway()
    {
        // Move towards this position
        Vector3 targetPosition = enemyHandle.position;

        // To find the diurection from A to B = B - A
        Vector3 delta = targetPosition - moveHandle.position;
        Vector3 moveDirection = delta.normalized;

        moveHandle.position -= moveDirection * moveSpeed * Time.deltaTime;
    }

    public void UpdateIdle()
    {
        // This function will do NOTHING

    }
}
