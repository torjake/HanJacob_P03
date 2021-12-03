using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _health = 20;
    public event Action<int> TookDamage;

    public void TakeDamage(int amount)
    {
        //print("took " + amount + " damage");
        _health -= amount;
        if (_health <= 0)
            Kill();
        //TODO update current health
        TookDamage?.Invoke(amount);
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
