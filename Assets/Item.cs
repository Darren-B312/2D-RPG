using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public int Id { get; set; }
    public string Name { get; set; }
}
