using System;
using UnityEngine;
public class PlayerLife : MonoBehaviour,IKillable
{

    public static event Action OnPlayerDeath;
    public Animator Animator;

    void Start()
    {
        Animator.SetBool("Death", false);
    }

    public void Die()
    {
        //TODO death animation

        Animator.SetBool("Death", true);
        OnPlayerDeath?.Invoke(); //Game over screen
    }


}
