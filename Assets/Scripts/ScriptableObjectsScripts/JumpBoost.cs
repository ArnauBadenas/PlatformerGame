using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Jump Boost")]
public class JumpBoost : Powerup
{
    public float jumpMultiplier = 1.5f;
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<PlayerJump>(out PlayerJump jumpScript))
        {
            jumpScript.JumpHeight *= jumpMultiplier;
        }

    }


    public override void Remove(GameObject target)
    {
        if (target.TryGetComponent<PlayerJump>(out PlayerJump jumpScript))
        {
            jumpScript.JumpHeight /= jumpMultiplier;
        }
    }
}
