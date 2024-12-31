using System;
using UnityEngine;


[CreateAssetMenu(fileName ="New Data",menuName = "Character Stats/Data")]
public class EntityStatus_SO : ScriptableObject
{
    public int coins;
    public Vector3 position;

    public int level;
    public float maxExp;
    public float currExp;

    public float maxMana;
    public float currMana;
    
    public float maxHealth;
    public float currHealth;
 
    public float speed;
    public float baseDamage;
    public float baseDefense;

    public int plotOrder;
    
    public EntityStatus_SO()
    {
        // 在这里进行初始化操作，或者留空
    }
    



}