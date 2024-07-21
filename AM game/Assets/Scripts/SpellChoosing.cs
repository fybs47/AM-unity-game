using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    public Button MagicShield;
    public Player Player1;
    public Player Player2;
    public int PlayerTurn;
    Player player;
    
    void PlayerDefenition()
    {
        if (PlayerTurn == 0)
        {
            player = Player1;
        }
        else
        {
            player = Player2;
        }
    }

    public void ChooseDirection()
     {
        PlayerDefenition();
        if (this.gameObject == FirstPosBtn.gameObject)
        {
            player.PlayerActions.Add(1);
        }
        else if (this.gameObject == SecondPosBtn.gameObject)
        {
            player.PlayerActions.Add(2);
        }
        else if (this.gameObject == ThirdPosBtn.gameObject)
        {
            player.PlayerActions.Add(3);
        }
        else if (this.gameObject == FourthPosBtn.gameObject)
        {
            player.PlayerActions.Add(4);
        }
        else if (this.gameObject == FifthPosBtn.gameObject)
        {
            player.PlayerActions.Add(5);
        }
        else if (this.gameObject == SixthPosBtn.gameObject)
        {
            player.PlayerActions.Add(6);
        }

        FirstPosBtn.interactable = false;
        SecondPosBtn.interactable = false;
        ThirdPosBtn.interactable = false;
        FourthPosBtn.interactable = false;
        FifthPosBtn.interactable = false;
        SixthPosBtn.interactable = false;

        DirectionSelectionWin.SetActive(false);
     }

    public void ChooseSpell()
    {   
        PlayerDefenition();
        if(this.card.spellType == SpellCard.Spells.movement &&  player.ActionCount >= 3)
        {
            DirectionSelectionWin.SetActive(true);
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
        if(this.card.spellType == SpellCard.Spells.shield && player.ActionCount >= 2 &&  player.Mana >= 2)
        {
            player.PlayerActions.Add(8);
            player.ActionCount -= 2;
            player.Mana -= 2;
            MagicShield.interactable = false;
        }
        else
        if(this.card.spellType == SpellCard.Spells.directionShot && player.ActionCount >= 2 &&  player.Mana >= 2)
        {
            DirectionSelectionWin.SetActive(true);
            player.PlayerActions.Add(9);
            player.ActionCount -= 2;
            player.Mana -= 2;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
        else
        if(this.card.spellType == SpellCard.Spells.reload && player.ActionCount >= 2 &&  player.Mana >= 1)
        {
            DirectionSelectionWin.SetActive(true);
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

    public void Cancel()
    {
        PlayerDefenition();
        FirstPosBtn.interactable = false;
        SecondPosBtn.interactable = false;
        ThirdPosBtn.interactable = false;
        FourthPosBtn.interactable = false;
        FifthPosBtn.interactable = false;
        SixthPosBtn.interactable = false;

        DirectionSelectionWin.SetActive(false);
        bool flag = true;
        while(flag && player.PlayerActions.Count > 0)
        {
            if (player.PlayerActions.Last<int>() <=6)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
            }
            if (player.PlayerActions.Last<int>() == 7)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += 3;
            }
            else
            if (player.PlayerActions.Last<int>() == 8)
            {
                flag = false;
                MagicShield.interactable = true;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += 2;
                player.Mana += 2;
            }
            else
            if (player.PlayerActions.Last<int>() == 9)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += 2;
                player.Mana += 2;
            }
            else
            if (player.PlayerActions.Last<int>() == 10)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += 2;
                player.Mana += 1;
            }
        }
    }

    public void TurnButton()
    {
        PlayerDefenition();
        int v = 0;
        while(player.PlayerActions.Count > 0 && v < 10)
        {
        Debug.Log(".Последний элемент:" + player.PlayerActions[player.PlayerActions.Count-1]);
        player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
        v++;
        }
    }
}
