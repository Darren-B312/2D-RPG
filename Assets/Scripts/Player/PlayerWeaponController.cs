﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private LayerMask combatLayer;
    private Transform attackPoint = null; // set this to be the players center?

    void Start()
    {
        attackPoint = transform;
    }

    void Update()
    {
        if (weapon.currentAttackCD <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                weapon.currentAttackCD = weapon.initialAttackCD;
            }

        } else
        {
            weapon.currentAttackCD -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        // play animation here

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weapon.attackRange, combatLayer);

        foreach(Collider2D h in hits)
        {
            Debug.Log($"HIT: {h.name}");
            Destroy(h.gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, weapon.attackRange);
        }
    }
}