using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "SpellCard")]
public class SpellCard : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public int manacost;
    public int actionsCost;
    public int damage;
}
