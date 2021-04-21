using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDemage(int damage_count = 1)
    {
        Die();
    }
    
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
