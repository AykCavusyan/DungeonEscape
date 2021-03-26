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
    
    protected Vector3 _currentTarget;

    protected bool _isHit = false;

    
    private GameObject _player;
    private Vector3 _playerPos;



    public virtual void FetchComponents()
    {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        FetchComponents();
        _currentTarget = pointB.position;
        _player = GameObject.Find("Player");
    }

    public virtual void Update()
    {
        _playerPos = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
        DetectPlayer();

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }
        else if (_anim.GetBool("InCombat") == true)
        {
            CombatMode();
        }

        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return;
        }
        else
            EnemyPatrol();
    }


    public virtual void EnemyPatrol()
    {
        if (_currentTarget == pointA.position)
        {
            _spriteRenderer.flipX = true;
        }

        else
            _spriteRenderer.flipX = false;

        if (transform.position == pointA.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointB.position;
        }

        else if (transform.position == pointB.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointA.position;
        }

       
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
            
        
    }   

    public virtual void DetectPlayer()
    {
        if (Mathf.Abs((transform.position.x) - (_playerPos.x)) < 2f)
        {
            
           _anim.SetBool("InCombat", true);
        }
        else
        {
            _anim.SetBool("InCombat", false);
        }
          
    }
    
    public virtual void CombatMode()
    {
        Vector3 direction = _player.transform.position - transform.position;

        if (direction.x > 0 && _anim.GetBool("InCombat") == true)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && _anim.GetBool("InCombat") == true)
        {
            _spriteRenderer.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_playerPos.x -0.5f, transform.position.y, transform.position.z) , _speed * Time.deltaTime);
        
        
    }



}
