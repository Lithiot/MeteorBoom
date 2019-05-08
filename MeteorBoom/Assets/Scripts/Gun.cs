using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject {

    public new string name;

    public Sprite sprite;

    public int damage;
    public float rateOfFire;

    public int price;
}
