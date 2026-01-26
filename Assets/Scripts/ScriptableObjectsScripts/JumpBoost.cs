using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Jump Boost")]
public class JumpBoost : PowerUp
{
    public float JumpMultiplier = 1.5f;
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent<PlayerJump>(out PlayerJump jumpScript))
        {
            jumpScript.JumpHeight *= JumpMultiplier;
        }
    }

    public override void Remove(GameObject target)
    {
        if (target.TryGetComponent<PlayerJump>(out PlayerJump jumpScript))
        {
            jumpScript.JumpHeight /= JumpMultiplier;
        }
    }
}
