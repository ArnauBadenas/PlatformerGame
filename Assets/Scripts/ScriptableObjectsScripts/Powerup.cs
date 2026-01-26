using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public float duration;

    public abstract void Apply(GameObject target);
    public abstract void Remove(GameObject target);
}
