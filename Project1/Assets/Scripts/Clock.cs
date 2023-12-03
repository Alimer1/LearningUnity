using System;
using UnityEngine;

public class Clock : UnityEngine.MonoBehaviour
{

    private const float hoursToDegrees = -30f;
    private const float minutesToDegrees = -6f;
    private const float secondToDegrees = -6f;

    TimeSpan time = DateTime.Now.TimeOfDay;

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    void Update()
    {
        Debug.Log(DateTime.Now);

        time = DateTime.Now.TimeOfDay;

        hoursPivot.localRotation =      Quaternion.Euler(0f,0f,hoursToDegrees *     (float)time.TotalHours);
        minutesPivot.localRotation =    Quaternion.Euler(0f,0f,minutesToDegrees *   (float)time.TotalMinutes);
        secondsPivot.localRotation =    Quaternion.Euler(0f,0f,secondToDegrees *    (float)time.TotalSeconds);
    }
}