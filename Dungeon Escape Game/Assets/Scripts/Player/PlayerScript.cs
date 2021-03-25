using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] private float jumpforce = 5.0f;
    [SerializeField] private bool grounded;
    [SerializeField] private LayerMask _groundLayer;
    private bool resetJumpNeeded = false;
    [SerializeField] private float speed;
    private PlayerAnimationScript _playeranim;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArc;
    private PlayerAttackScript _playerAttack;

    

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        speed = 2.5f;
        _playeranim = GetComponent<PlayerAnimationScript>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArc = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();

        //_swordArc.transform.localEulerAngles = new Vector3(78, 48, -80);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        grounded = IsGrounded();
    }

    //IEnumerator ResetJumpNeededRoutine()
    //{
    //    yield return new WaitForSeconds(0.05f);
    //    resetJumpNeeded = false;
    //}

    void Movement()
    {
        //horizontal movement
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            _swordArc.transform.localEulerAngles = new Vector3(Random.Range(65,79),Random.Range(-55,55),Random.Range(-40,-85));
            _playeranim.Attack();
            
        }



        //jumping 
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump");
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
            
            StartCoroutine(ResetJumpRoutine());
            _playeranim.JumpAnimation(true);
        }

        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);
        _playeranim.MoveAnimation(move);

        //if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        //{
        //    _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
        //    grounded = false;
        //    resetJumpNeeded = true;
        //    StartCoroutine(ResetJumpNeededRoutine());
        //}
    }

    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        if (hitinfo.collider != null)
        {
            if (resetJumpNeeded == false)
                _playeranim.JumpAnimation(false);
            return true;
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJumpNeeded = true;
        
        yield return new WaitForSeconds(0.1f);
        
        resetJumpNeeded = false;
       

    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _spriteRenderer.flipX = false;
            _swordArc.flipX = false;
            _swordArc.flipY = false;

            Vector3 newPos = _swordArc.transform.localPosition;
            newPos.x = 1.01f;
            _swordArc.transform.localPosition = newPos;

            //_swordArc.transform.localEulerAngles = new Vector3(78, 48, -80);

        }
        else if (faceRight == false)
        {
            _spriteRenderer.flipX = true;
            _swordArc.flipX = true;
            _swordArc.flipY = true;

            Vector3 newPos = _swordArc.transform.localPosition;
            newPos.x = -1.01f;
            _swordArc.transform.localPosition = newPos;

            //_swordArc.transform.localEulerAngles = new Vector3(-78, -48, 80);
        }
    }



    //void CheckGrounded()
    //{
    //    RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer);

    //    if (hitinfo.collider != null)
    //    {
    //        if (resetJumpNeeded == false)
    //        {
    //            grounded = true;
    //        }


    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        grounded = true;
    //    }
    //}
    
        
        
       
   
    
}
