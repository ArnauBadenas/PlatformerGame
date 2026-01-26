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
        Animator.SetBool("Death", true);
    }
}
