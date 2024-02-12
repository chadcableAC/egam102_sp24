using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeElement : MonoBehaviour
{
    public Apple[] appleArray;

    public List<Apple> appleList;

    void Start()
    {
        // Using LISTS

        // FOR EACH
        foreach (Apple apple in appleList)
        {
            // This will run for EACH apple in the list
            apple.Fall();
        }

        // FOR LOOP
        // Where to START counting; how LONG to count; HOW to count
        for (int i = 0; i < appleList.Count; i++)
        {
            Apple apple = appleList[i];
            apple.Fall();
        }

        // Using ARRAYS

        // FOR EACH
        foreach (Apple apple in appleArray)
        {
            // This will run for EACH apple in the list
            apple.Fall();
        }

        // FOR LOOP
        // Where to START counting; how LONG to count; HOW to count
        for (int i = 0; i < appleList.Count; i++)
        {
            Apple apple = appleList[i];
            apple.Fall();
        }
    }

    void Update()
    {
        
    }
}
