using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _startVolume;
    [SerializeField] private float _volumeIncreaseDuration;

    private AudioSource _alarmSignal;
    private float _stopPoint;
    private int _volumeModify;

    private void Start()
    {
        _alarmSignal = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume() 
    {
        while (_alarmSignal.volume != _stopPoint)
        {
            _alarmSignal.volume += Time.deltaTime * _volumeModify / _volumeIncreaseDuration;

            yield return null;
        }
    }

    public void IncreaseVolume()
    {
        _alarmSignal.volume = 0.0f;
        _stopPoint = 1;
        _volumeModify = 1;

        StartCoroutine(ChangeVolume());

        _alarmSignal.Play();
    }

    public void DecreaseVolume()
    {
        _stopPoint = 0;
        _volumeModify = -1;

        StartCoroutine(ChangeVolume());
    }
}
