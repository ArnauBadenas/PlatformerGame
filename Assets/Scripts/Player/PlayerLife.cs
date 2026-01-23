using System;
using UnityEngine;
public class PlayerLife : MonoBehaviour,IKillable
{

    public static event Action OnPlayerDeath;

    public void Die()
    {
        //TODO death animation
        OnPlayerDeath?.Invoke(); //Game over screen
    }


}
