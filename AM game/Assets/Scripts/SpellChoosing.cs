using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellChoosing : MonoBehaviour
{   
     GameManager gameManager;
     public SpellCard card;
     public GameObject DirectionSelectionWin;
     public Button FirstPosBtn;
     public Button SecondPosBtn;
     public Button ThirdPosBtn;
     public Button FourthPosBtn;
     public Button FifthPosBtn;
     public Button SixthPosBtn; 
     Player player;

    
     public void ChooseSpell()
     {

        gameManager.PlayerDefinition(player);
        DirectionSelectionWin.SetActive(true);
        if(this.card.spellType == SpellCard.Spells.movement)
        {
            player.PlayerActions.Add(7);
            player.ActionCount -= 3;
            if(player.Position == 2)
            {
                FirstPosBtn.interactable = true;
                ThirdPosBtn.interactable = true;
            }
            else
            {
                SecondPosBtn.interactable= true;
            }
        }
        else
        if(this.card.spellType == SpellCard.Spells.shield)
        {
            player.PlayerActions.Add(8);
            player.ActionCount -= 2;
            player.Mana -= 2;
        }
        else
        if(this.card.spellType == SpellCard.Spells.directionShot)
        {
            player.PlayerActions.Add(9);
            player.ActionCount -= 2;
            player.Mana -= 2;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
        else
        {
            player.PlayerActions.Add(10);
            player.ActionCount -= 2;
            player.Mana -= 1;
            FirstPosBtn.interactable = true;
            SecondPosBtn.interactable = true;
            ThirdPosBtn.interactable = true;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
     }
}
