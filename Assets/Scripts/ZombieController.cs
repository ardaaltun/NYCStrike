using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour, IBase
{
    [SerializeField] private int _health = 100;
    Animator _animator;
    CapsuleCollider _collider;
    Rigidbody _rb;

    NavMeshAgent _agent;

    GameObject _player;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _agent = GetComponent<NavMeshAgent>();
        _animator.SetTrigger("Alive");
        _player = GameObject.FindGameObjectWithTag("Player");

    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        this.CheckHealth();
    }

    void Update() {
        if (_agent.enabled)
        {
            _agent.destination = _player.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, _player.transform.position);
            if (distance < 2f)
            {
                // _animator.SetTrigger("attack");
                // _agent.velocity = Vector3.zero;
            }

        }
    }
    void CheckHealth()
    {
        if(this._health < 0)
        {
            this.Death();
        }
    }

    void Death()
    {
        Destroy(_rb);
        _collider.enabled = false;
        _animator.SetTrigger("Die");
        _agent.enabled = false;
        // GetComponent<sfxController>().Died();
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }
}
