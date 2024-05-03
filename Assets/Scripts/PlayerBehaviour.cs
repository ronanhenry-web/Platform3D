using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public WeaponData Weapon;
    public Transform FireOrigin;
    public float Speed;
    public float RotationSpeed;
    public float SensitivityX;
    public float SensitivityY;
    public float JumpForce;
    public float Gravity;

    private CharacterController _c;
    private Vector3 _velocity;
    private float _rotationY;
    private float _fireTimer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity.y += Gravity * Time.deltaTime;
        Vector3 movement = _velocity;

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * SensitivityX;
        _rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
        transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);

        if (Input.GetKey(KeyCode.W))
            movement += transform.forward * Speed;
        if (Input.GetKey(KeyCode.S))
            movement -= transform.forward * Speed;
        if (Input.GetKey(KeyCode.A))
            movement -= transform.right * Speed;
        if (Input.GetKey(KeyCode.D))
            movement += transform.right * Speed;
        if (Input.GetKeyDown(KeyCode.Space) && _c.isGrounded)
            _velocity.y = JumpForce;
        if (Input.GetMouseButton(0) && Weapon != null)
        {
            if (_fireTimer <= 0)
            {
                _fireTimer = Weapon.FireRate;
                if (Weapon.Type == FireType.Projectile)
                {
                    ProjectileBehaviour projectile = Instantiate(Weapon.Projectile, FireOrigin.position, transform.localRotation);
                    projectile.Damage = Weapon.Damage;
                }
                else
                {
                    if (Physics.Raycast(FireOrigin.position, transform.forward, out RaycastHit hitscan))
                    {
                        if (hitscan.collider.GetComponentInParent<HitableBehaviour>() is HitableBehaviour hitable)
                            hitable.OnHit?.Invoke(Weapon.Damage);
                    }
                }
            }
        }

        if (_fireTimer > 0)
            _fireTimer -= Time.deltaTime;

        _c.Move(movement * Time.deltaTime);
    }
}
