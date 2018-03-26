using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool continuous = false;

    const float degreePerHour = 30f;
    const float degreePerMinute = 6f;
    const float degreePerSecond = 6f;

    void Start()
    {
        UpdateDiscrete();
    }

    void Update()
    {
        if (continuous)
            UpdateContinuous();
        else
            UpdateDiscrete();
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(0, time.Hour * degreePerHour, 0);
        minutesTransform.localRotation = Quaternion.Euler(0, time.Minute * degreePerMinute, 0);
        secondsTransform.localRotation = Quaternion.Euler(0, time.Second * degreePerSecond, 0);
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler(0, (float)time.TotalHours * degreePerHour, 0);
        minutesTransform.localRotation = Quaternion.Euler(0, (float)time.TotalMinutes * degreePerMinute, 0);
        secondsTransform.localRotation = Quaternion.Euler(0, (float)time.TotalSeconds * degreePerSecond, 0);
    }

}
