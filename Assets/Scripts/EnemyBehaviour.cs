using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent Nav;
    public Animator Animator;

    [HideInInspector]
    public Transform Player;

    private bool _isDead = false;

    private void Start()
    {
        Player = GameManager.Instance.Player.transform;
    }

    void Update()
    {
        if (_isDead)
            return;

        if (Nav != null && Nav.isActiveAndEnabled)
        {
            Nav.SetDestination(Player.position);
            transform.LookAt(Player.position);
        }
    }

    public void Kill()
    {
        _isDead = true;
        Destroy(Nav);
        Animator.Play("Death");
    }
}
