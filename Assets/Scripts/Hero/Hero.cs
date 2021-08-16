using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static Hero instance;
    [SerializeField] private Image _hpBar;
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private float _hpDecreaseTimer = 0.25f;
    private float _currentTimer;
    private int _hp;
    private bool _invulnerability;
    private Animator _animator;
    public event Action OnHeroDead; 

    public int Hp { get => _hp; set => UpdateHpValue(value); }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Hp = _maxHp;
        _animator = GetComponent<Animator>();
        _currentTimer = _hpDecreaseTimer;
    }
    private void OnEnable()
    {
        //OnHeroDead += UIManager.instance.ShowGameOverPanel;
    }
    private void Update()
    {
        if (_currentTimer <= 0)
        {
            Hp -= 1;
            _currentTimer = _hpDecreaseTimer;
        }
        else
            _currentTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!_invulnerability)
            {
                TakeHit(10);
            }
        }
    }
    private void TakeHit(int damageValue)
    {
        Hp -= damageValue;
        _animator.SetTrigger("damage");
        StartCoroutine(Invulnerability());
    }
    private void UpdateHpValue(int value)
    {
        _hp = Mathf.Clamp(value,0,_maxHp);
        _hpBar.fillAmount = (float) _hp / _maxHp;
        if (_hp <= 0)
        {
            UIManager.instance.ShowGameOverPanel();
            _animator.SetTrigger("dead");
            OnHeroDead?.Invoke();
            //ObjectPooler.instance.spawning = false;
            HeroController.instace.enabled = false;
            enabled = false;
        }
    }
    private IEnumerator Invulnerability()
    {
        _invulnerability = true;
        yield return new WaitForSeconds(.5f);
        _invulnerability = false;
    }
}
