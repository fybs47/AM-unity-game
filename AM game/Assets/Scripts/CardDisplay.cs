using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
 public SpellCard Card;

 public Text NameText;
 public Text DescriptionText;

 public TextMeshProUGUI ManaCostTxt;
 public TextMeshProUGUI ActionsCostTxt;

 
 public Image SpriteImage;

 

    void Start()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        ManaCostTxt.text = Card.manacost.ToString();
        ActionsCostTxt.text = Card.actionsCost.ToString();
        SpriteImage.sprite = Card.sprite;
        
        if(Card.manacost <= 0)
        {
            ManaCostTxt.gameObject.SetActive(false);
        }
        if(Card.actionsCost <= 0)
        {
            ActionsCostTxt.gameObject.SetActive(false);
        }
    }
}
