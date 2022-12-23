using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _escapePosition;

    private bool _isEscape;
    private Animator _animator;

    private void Start()
    {
        _animator= GetComponent<Animator>();
        _isEscape= false;
    }

    private void Update()
    {
        _animator.SetFloat("speed", _speed);

        if (_isEscape == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            if (transform.position == _target.position)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                _isEscape = true;
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _escapePosition.position, _speed * Time.deltaTime);
        }
    }
}
