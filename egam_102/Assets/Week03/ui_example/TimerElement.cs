using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerElement : MonoBehaviour
{
    public Slider slider;

    public float duration = 10f;
    private float timer = 0;

    void Start()
    {
        // Start at the duration amount
        timer = duration;
    }

    void Update()
    {
        // Subtract this frame's duration
        timer -= Time.deltaTime;

        // Turns the timer into a value between 0 and 1
        float interp = timer / duration;
        slider.value = interp;
    }
}
