using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Mana;
    public int Hp;
    public int Position;
    public int ActionCount;
    public bool Protected;
    public List<int> PlayerActions;
    public TextMeshProUGUI PlayerHPtxt;
    public TextMeshProUGUI PlayerManatxt;

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
       Protected = false;
       PlayerActions = new List<int>();
    }

    public void UpdateHP()
    {
        PlayerHPtxt.text = Hp.ToString();
    }

        public void UpdateMana()
    {
        PlayerManatxt.text = Mana.ToString();
    }
}
