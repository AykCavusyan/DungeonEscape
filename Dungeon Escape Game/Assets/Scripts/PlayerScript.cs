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


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        speed = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

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
        _rigid.velocity = new Vector2(move*speed, _rigid.velocity.y);

        //jumping 
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump");
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
            StartCoroutine(ResetJumpRoutine());
        }

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
