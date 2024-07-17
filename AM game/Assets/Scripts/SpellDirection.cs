using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDirection : MonoBehaviour
{   
     public SpellCard card;
     public GameObject DirectionSelectionWin;
     public Button FirstPosBtn;
     public Button SecondPosBtn;
     public Button ThirdPosBtn;
     public Button FourthPosBtn;
     public Button FifthPosBtn;
     public Button SixthPosBtn;

     public void ChooseSpell()
     {
        DirectionSelectionWin.SetActive(true);
        if(this.card.directions == SpellCard.Directions.toMyself)
        {
            SecondPosBtn.interactable = true;
        }
        else
        if(this.card.directions == SpellCard.Directions.toEnemy)
        {
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
        else
        {
            FirstPosBtn.interactable = true;
            SecondPosBtn.interactable = true;
            ThirdPosBtn.interactable = true;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
     }
}
