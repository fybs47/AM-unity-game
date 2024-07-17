using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
 public SpellCard card;

 public Text nameText;
 public Text descriptionText;
 
 public Image spriteImage;

 

    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        spriteImage.sprite = card.sprite;
    }
}
