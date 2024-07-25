using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionDisplay : MonoBehaviour
{

 public SpellCard Card;

 public TextMeshProUGUI ManaCostTxt;
 public TextMeshProUGUI ActionsCostTxt;
 
 public Image SpriteImage;

 

    void Start()
    {
        ManaCostTxt.text = Card.manacost.ToString();
        ActionsCostTxt.text = Card.actionsCost.ToString();
        SetSprite("Sprites/Numbers/1-Pos");
        if(Card.manacost <= 0)
        {
            ManaCostTxt.gameObject.SetActive(false);
        }
        if(Card.actionsCost <= 0)
        {
            ActionsCostTxt.gameObject.SetActive(false);
        }
    }

    public void SetSprite(string spritePath)
    {
        SpriteImage.sprite = Resources.Load<Sprite>(spritePath);
    }

}
