using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmSignal))]

public class MotionSensor : MonoBehaviour
{
    private AlarmSignal _alarmSignal; 

    private void Start()
    {
        _alarmSignal = GetComponent<AlarmSignal>();
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
