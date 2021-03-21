using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _speed;
    [SerializeField] protected int _gems;
    [SerializeField] protected Transform pointA, pointB;
    protected Animator _anim;
    protected SpriteRenderer _spriteRenderer;


    public virtual void FetchComponents()
    {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Attack()
    {
        Debug.Log("My name is :" + this.gameObject.name);
    }

    public abstract void Update();
   

}
