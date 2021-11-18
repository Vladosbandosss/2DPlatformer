using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static Lock instance;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UnlockTheDoor()
    {
        anim.Play("unlock");
    }

}
