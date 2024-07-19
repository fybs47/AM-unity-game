using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellChoosing : MonoBehaviour
{   
     public SpellCard card;
     public GameObject DirectionSelectionWin;
     public Button FirstPosBtn;
     public Button SecondPosBtn;
     public Button ThirdPosBtn;
     public Button FourthPosBtn;
     public Button FifthPosBtn;
     public Button SixthPosBtn;

     public Player player1;
     public Player player2;
     public int PlayerTurn;
     Player player;


     
    

     public void ChooseSpell()
     {
        DirectionSelectionWin.SetActive(true);
        if(this.card.spellType == SpellCard.Spells.movement)
        {
            player.PlayerActions.Add(7);
            player.actionCount -= 3;
            if(player.position == 2)
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
            player.actionCount -= 2;
            player.mana -= 2;
        }
        else
        if(this.card.spellType == SpellCard.Spells.directionShot)
        {
            player.PlayerActions.Add(9);
            player.actionCount -= 2;
            player.mana -= 2;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
        else
        {
            player.PlayerActions.Add(10);
            player.actionCount -= 2;
            player.mana -= 1;
            FirstPosBtn.interactable = true;
            SecondPosBtn.interactable = true;
            ThirdPosBtn.interactable = true;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
     }
}
