using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Alarm))]

public class MotionSensor : MonoBehaviour
{
    private Alarm _alarmSignal; 

    private void Start()
    {
        _alarmSignal = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            _alarmSignal.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            _alarmSignal.Stop();
        }
    }
}
