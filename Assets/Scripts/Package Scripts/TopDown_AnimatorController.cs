using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_AnimatorController : MonoBehaviour
{
    public float attacking;
    public float cooldown;
    [SerializeField]
    RuntimeAnimatorController animShovel;

    [SerializeField]
    RuntimeAnimatorController animAxe;

    public bool IsAttacking { get; private set; }

    Animator anim;
    SpriteRenderer sprite;

    private void Start()
    {
        cooldown = 600;
        attacking = 0;
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animShovel;
        sprite = GetComponent<SpriteRenderer>();

        //start off facing to the right.
        anim.SetBool("IsWalking", false);
        anim.SetInteger("WalkDir", 2);
        sprite.flipX = true;

    }

    private void Update()
    {
        cooldown -= 1;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("IsWalking", true);
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = true;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = false;
                }
            }
            else
            {
                anim.SetBool("IsWalking", true);
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = true;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = false;
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    anim.SetInteger("WalkDir", 0);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    anim.SetInteger("WalkDir", 2);
                }
            }
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        attacking = 0;
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Attack");
            if (cooldown < 600)
            { 
            attacking = 1;
            
            }
            anim.SetBool("IsWalking", false);
        }

        IsAttacking = anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack");

    }

    // Call this function when the player picks up the axe.
    public void SwitchToAxe()
    {
        anim.runtimeAnimatorController = animAxe;
    }

    // Call this function to set the weapon back to a shovel.
    public void SwitchToShovel()
    {
        anim.runtimeAnimatorController = animShovel;
    }
}