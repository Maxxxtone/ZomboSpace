using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public static HeroController Instance;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _horizontalConstraint = 8f, _verticalConstraint = 3.5f;
    [SerializeField] private GameObject _jetpackParticles;
    [SerializeField] private float _jetpackTime = 5f;
    private Vector3 _targetPosition;
    private bool _speedIncreased;
    private float _timer;
    private float _initialSpeed;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _initialSpeed = _speed;
    }
    private void Update()
    {
        Move();
        if (_speedIncreased)
        {
            if (_timer <= 0)
            {
                _speed = _initialSpeed;
                _speedIncreased = false;
                _jetpackParticles.SetActive(false);
            }
            else
                _timer -= Time.deltaTime;
        }
    }
    public void IncreaseSpeed()
    {
        _jetpackParticles.SetActive(true);
        _timer = _jetpackTime;
        _speedIncreased = true;
    }
    private void Move()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.x = Mathf.Clamp(mousePos.x, -_horizontalConstraint, _horizontalConstraint);
        _targetPosition.y = Mathf.Clamp(mousePos.y, -_verticalConstraint, _verticalConstraint);
        _targetPosition.z = 10;
        Flip(_targetPosition.x);
        transform.position = Vector2.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
    private void Flip(float targetX)
    {
        if (transform.position.x > targetX)
            LeanTween.rotateY(gameObject, 180, .25f);
        else if (transform.position.x < targetX)
            LeanTween.rotateY(gameObject, 0, .25f);
    }
}
