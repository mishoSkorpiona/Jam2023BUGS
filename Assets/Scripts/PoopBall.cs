using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    public float damage = 10;
    public bool explosive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        if (explosive)
        {
            Explode();
            damage *= 1.8f;
        }

        DealDamage(collision.gameObject);
    }

    void Explode()
    {
        _animator.Play("Explosion");
    }

    void DealDamage(GameObject player)
    {
        player.GetComponent<PlayerManager>().TakeDamage(damage);
        Destroy(this);
    }
}
