using System;
using UnityEngine;

public class DateController
{
    const float TIME_RATIO = 48;
    private DateTime startDate;
    private float startUnityTime;

    public DateController(DateTime _startDate)
    {
        startDate = _startDate;
        startUnityTime = Time.time;
    }

    public TimeSpan TimeElapsed
    {
        get
        {
            float secondsElapsed = Time.time - startUnityTime;
            double scaledSecondsElapsed = secondsElapsed * TIME_RATIO;
            TimeSpan elapsed = TimeSpan.FromSeconds(scaledSecondsElapsed);
            return elapsed;
        }
    }

    public DateTime InGameTime => startDate + TimeElapsed;
}
