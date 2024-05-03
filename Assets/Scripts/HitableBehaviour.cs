using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class HitableBehaviour : MonoBehaviour
{
    public UnityEvent<int> OnHit;
}
