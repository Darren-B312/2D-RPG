using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] public float initialAttackCD = 2;
    [SerializeField] public float currentAttackCD = 0;
    [SerializeField] public float attackRange = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
