using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSignal : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _volumeIncreaseDuration;

    private AudioSource _alarmSignal;

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

    private void Start()
    {
        _alarmSignal= GetComponent<AudioSource>();
    }

    private IEnumerator IncreaseVolume() 
    {
        while (_alarmSignal.volume < 1)
        {
            _alarmSignal.volume += Time.deltaTime / _volumeIncreaseDuration;

            yield return null;
        }
    }
}
