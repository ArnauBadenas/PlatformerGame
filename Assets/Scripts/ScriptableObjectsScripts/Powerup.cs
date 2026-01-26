using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public float Duration;

    public abstract void Apply(GameObject target);
    public abstract void Remove(GameObject target);
}
