using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayer : MonoBehaviour
{
    public List<ArrowElement> exampleArrows;
    public List<ArrowElement> playerArrows;

    public enum Directions
    {
        Left,   // 0
        Up,     // 1
        Right,  // 2
        Down    // 3
    }

    public int minimumDirectionCount = 2;
    public int maximumDirectionCount = 8;

    public List<Directions> exampleDirectionList;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteDirections());
    }

    IEnumerator ExecuteDirections()
    {
        // Resetting the list
        exampleDirectionList.Clear();

        // Adding a random number of directions
        int randomDirectionCount = Random.Range(minimumDirectionCount, maximumDirectionCount);
        for (int i = 0; i < randomDirectionCount; i++)
        {
            // Each loop, find a new random dirction
            int directionInt = Random.Range(0, 4);
            Directions direction = (Directions) directionInt;

            // Add it to our list
            exampleDirectionList.Add(direction);
        }

        // Start with everything turned off
        TurnAllOff(exampleArrows);

        // Show each directionb
        foreach (Directions direction in exampleDirectionList)
        {
            SetDirection(exampleArrows, direction);
            yield return new WaitForSeconds(1f);

            // Turn off for a small time (That way we can see if a direction
            // happens twice in a row)
            TurnAllOff(exampleArrows);
            yield return new WaitForSeconds(0.2f);
        }

        // Turn everythign off
        TurnAllOff(exampleArrows);
    }

    public void SetDirection(List<ArrowElement> arrowList, Directions newDirection)
    {
        foreach (ArrowElement arrow in arrowList)
        {
            // Turn on if the directions match
            bool isOn = newDirection == arrow.ourDirection;
            arrow.SetOn(isOn);
        }
    }

    public void TurnAllOff(List<ArrowElement> arrowList)
    {
        foreach (ArrowElement arrow in arrowList)
        {
            arrow.SetOn(false);
        }
    }
}
