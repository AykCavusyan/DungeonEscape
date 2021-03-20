using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{

    private Animator _anim;
    private Animator _swordAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void MoveAnimation(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void JumpAnimation(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnimation.SetTrigger("SwordArcTrigger");
    }

    

}


