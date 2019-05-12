using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Transform enemy;
    public int damage = 50;
   
    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth e = other.GetComponent<EnemyHealth>();
        if(e)
        {
            Destroy(gameObject);
            e.TakeDamage(damage);
        }

    }
    
}
