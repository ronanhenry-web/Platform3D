using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed;
    public float MaxDistance;

    [HideInInspector]
    public int Damage;

    private Rigidbody _rb;
    private Vector3 _startingPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startingPosition = transform.position;

        _rb.velocity = transform.forward * Speed;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _startingPosition) > MaxDistance)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //HitableBehaviour hitable = other.GetComponent<HitableBehaviour>();
        //if (hitable != null)
        //{
        //}

        if (other.GetComponentInParent<HitableBehaviour>() is HitableBehaviour hitable)
        {
            hitable.OnHit?.Invoke(Damage);
        }
        Destroy(gameObject);
    }
}
