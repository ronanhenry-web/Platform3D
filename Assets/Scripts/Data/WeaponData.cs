using Sirenix.OdinInspector;
using UnityEngine;

public enum FireType
{
    Projectile,
    Hitscan
}

[CreateAssetMenu(menuName = "Game/Weapon")]
public class WeaponData : ScriptableObject
{
    public string Name;
    public int Damage;
    public float FireRate;
    public float ReloadTime;

    public FireType Type;
    [ShowIf("@" + nameof(Type) + " == " + nameof(FireType) + "." + nameof(FireType.Projectile))]
    public ProjectileBehaviour Projectile;
}
