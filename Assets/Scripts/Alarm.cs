using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _volumeIncreaseDuration;

    private AudioSource _alarmSignal;
    private float _maxVolume;

    private void Start()
    {
        _maxVolume = 1;
        _alarmSignal = GetComponent<AudioSource>();
    }

    private IEnumerator IncreaseVolume() 
    {
        while (_alarmSignal.volume < _maxVolume)
        {
            _alarmSignal.volume += Time.deltaTime / _volumeIncreaseDuration;

            yield return null;
        }
    }

    public void Play()
    {
        _alarmSignal.volume = 0.0f;

        StartCoroutine(IncreaseVolume());

        _alarmSignal.Play();
    }

    public void Stop()
    {
        StopCoroutine(IncreaseVolume());

        _alarmSignal.Stop();
    }
}
