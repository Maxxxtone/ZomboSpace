using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Transform _heroTransform;
    public event Action OnEnemyDead;
    private ObjectPooler _objectPooler;
    private Animator _animator;
    private void Start()
    {
        _objectPooler = ObjectPooler.instance;
        _animator = GetComponent<Animator>();
        OnEnemyDead += ShakeCamera.instance.Shake;
        OnEnemyDead += GameLoop.instance.UpdateScore;
    }
    private void OnEnable()
    {
        if(_animator == null)
            _animator = GetComponent<Animator>();
        _animator.SetTrigger("spawn");
    }
    private void Update()
    {
        if (!_heroTransform)
            _heroTransform = GameLoop.instance.HeroPosition;
        Flip(_heroTransform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, _heroTransform.position, _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyDead();   
        }
    }
    public void EnemyDead()
    {
        OnEnemyDead?.Invoke();
        _objectPooler.SpawnObjectFromQueue("enemy_death", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    private void Flip(float targetX)
    {
        if (transform.position.x > targetX)
            LeanTween.rotateY(gameObject, 180, .1f);
        else if (transform.position.x < targetX)
            LeanTween.rotateY(gameObject, 0, .1f);
    }
}
