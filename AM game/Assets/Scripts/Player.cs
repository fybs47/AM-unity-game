using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Mana;
    public int Hp;
    public int Position;
    public int ActionCount;
    public List<int> PlayerActions = new List<int>();

    //1-6 -- is position;
    //7 - is movement;
    //8 - is shield;
    //9 - is direction shot;
    //10 - is reload;

    public Player(int mana, int hp, int position, int actionCount)
    {
       Mana = mana;
       Hp = hp;
       Position = position;
       ActionCount = actionCount;
    }
}
