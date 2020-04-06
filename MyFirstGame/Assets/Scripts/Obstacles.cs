﻿using UnityEngine;


public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var unit = collider.GetComponent<Unit>();
        if(unit && unit as Character)
            unit.ReceiveDamage();
    }
}