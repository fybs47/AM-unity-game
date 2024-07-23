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

    public SpellCard Movement;
    public SpellCard MagicShield;
    public SpellCard DirectionShot;
    public SpellCard Reload;
    public Button MovementBtn;
    public Button MagicShieldBtn;
    public Button DirectionShotBtn;
    public Button ReloadBtn;
    public Player Player1;
    public Player Player2;
    Player player;
    public static bool UsedShield;

    void Start()
    {
        UsedShield = false;
    }

    void PlayerDefenition()
    {
        if (TurnController.instance.PlayerTurn == 0)
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

        MovementBtn.interactable = true;
        if (UsedShield == false)
        {
            Debug.Log("used sdield is: " + UsedShield.ToString());
            MagicShieldBtn.interactable = true; 
        }
        DirectionShotBtn.interactable = true;
        ReloadBtn.interactable = true;

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
            MovementBtn.interactable = false;
            MagicShieldBtn.interactable = false;
            DirectionShotBtn.interactable = false;
            ReloadBtn.interactable = false;
            player.PlayerActions.Add(7);
            player.ActionCount -= Movement.actionsCost;
            if (TurnController.instance.PlayerTurn == 0)
            {
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
            {
                if(player.Position == 5)
                {
                    FourthPosBtn.interactable = true;
                    SixthPosBtn.interactable = true;
                }
                else
                {
                    FifthPosBtn.interactable= true;
                }
            } 
        }
        else
        if(this.card.spellType == SpellCard.Spells.shield && player.ActionCount >= 2 &&  player.Mana >= 2)
        {
            player.PlayerActions.Add(8);
            player.ActionCount -= MagicShield.actionsCost;
            player.Mana -= MagicShield.manacost;
            UsedShield = true;
            Debug.Log("in Spell: " + UsedShield.ToString());
            MagicShieldBtn.interactable = false;
        }
        else
        if(this.card.spellType == SpellCard.Spells.directionShot && player.ActionCount >= 2 &&  player.Mana >= 2)
        {
            DirectionSelectionWin.SetActive(true);
            MovementBtn.interactable = false;
            MagicShieldBtn.interactable = false;
            DirectionShotBtn.interactable = false;
            ReloadBtn.interactable = false;
            player.PlayerActions.Add(9);
            player.ActionCount -= DirectionShot.actionsCost;
            player.Mana -= DirectionShot.manacost;
            if (TurnController.instance.PlayerTurn == 0)
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
            }
        }
        else
        if(this.card.spellType == SpellCard.Spells.reload && player.ActionCount >= 2 &&  player.Mana >= 1)
        {
            DirectionSelectionWin.SetActive(true);
            MovementBtn.interactable = false;
            MagicShieldBtn.interactable = false;
            DirectionShotBtn.interactable = false;
            ReloadBtn.interactable = false;
            player.PlayerActions.Add(10);
            player.ActionCount -= Reload.actionsCost;
            player.Mana -= Reload.manacost;
            FirstPosBtn.interactable = true;
            SecondPosBtn.interactable = true;
            ThirdPosBtn.interactable = true;
            FourthPosBtn.interactable = true;
            FifthPosBtn.interactable = true;
            SixthPosBtn.interactable = true;
        }
        Debug.Log("in the end of this method: " + UsedShield.ToString());
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

        MovementBtn.interactable = true;
        if (UsedShield == false)
        {
            MagicShieldBtn.interactable = true; 
        }
        DirectionShotBtn.interactable = true;
        ReloadBtn.interactable = true;

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
                player.ActionCount += Movement.actionsCost;
            }
            else
            if (player.PlayerActions.Last<int>() == 8)
            {
                flag = false;
                MagicShieldBtn.interactable = true;
                UsedShield = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += MagicShield.actionsCost;
                player.Mana += MagicShield.manacost;
            }
            else
            if (player.PlayerActions.Last<int>() == 9)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += DirectionShot.actionsCost;
                player.Mana += DirectionShot.manacost;
            }
            else
            if (player.PlayerActions.Last<int>() == 10)
            {
                flag = false;
                player.PlayerActions.RemoveAt(player.PlayerActions.Count-1);
                player.ActionCount += Reload.actionsCost;
                player.Mana += Reload.manacost;
            }
        }
    }
}
