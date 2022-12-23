using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSignal : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _volumeIncreaseDuration;

    private AudioSource _alarmSignal;

    private void Start()
    {
        _alarmSignal= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            _alarmSignal.volume = _startVolume;
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

    private void Update()
    {
        if (_alarmSignal.isPlaying) 
        {
            _alarmSignal.volume += (Time.deltaTime / _volumeIncreaseDuration);
        }
    }
}
