using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private SpriteRenderer sr;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    public void PlayWalk(int walk)
    {
        anim.SetInteger(TagManger.WALKANIMATIONPARAMETR, walk);
    }

    public void ChangeFacingDirection(int direction)
    {
        if (direction > 0)//right move
        {
            sr.flipX = false;
        }
        else if (direction < 0)//left move
        {
            sr.flipX = true;
        }
    }

    public void PlayJumpAndFall(int jumpFall)
    {
        anim.SetInteger(TagManger.JUMPANIMATIONPARAMETR, jumpFall);
    }
}
