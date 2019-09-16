using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int key_count = 0;
    int bomb_count = 0;
    float health_count = 3.0f;

    public void AddRupees(int num_rupees)
    {
        rupee_count += num_rupees;
    }

    public void UseRupees()
    {
        rupee_count -= 1;
    }

    public int GetRupees()
    {
        return rupee_count;
    }

    public void AddKeys(int num_keys)
    {
        key_count += num_keys;
    }

    public void UseKeys()
    {
        key_count -= 1;
    }

    public int GetKeys()
    {
        return key_count;
    }

    public void AddBomb(int num_bombs)
    {
        bomb_count += num_bombs;
    }

    public void UseBomb()
    {
        bomb_count -= 1;
    }

    public int GetBombs()
    {
        return bomb_count;
    }

    public void AddHealth(float add_amount)
    {
        health_count += add_amount;
    }

    public void UseHealth(float use_amount)
    {
        health_count -= use_amount;
    }

    public float GetHealth()
    {
        return health_count;
    }

    public bool IsFullHealth()
    {
        return System.Math.Abs(health_count - 3.0f) < 0.5;
    }
}
