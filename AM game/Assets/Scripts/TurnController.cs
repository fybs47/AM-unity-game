using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public static TurnController instance;
    
    public SpellCard Movement;
    public SpellCard MagicShield;
    public SpellCard DirectionShot;
    public SpellCard Reload;
    public Button MagicShieldBtn;
    public GameObject Result;
    public TextMeshProUGUI ResultTxt;
    public GameObject TieSprite;
    public GameObject Field;
    public TextMeshProUGUI TurnTxt;

    public Player Player1;
    public Player Player2;
    public int PlayerTurn;
    public GameManager gameManager;
    public GameObject ReloadPrefab;
    public GameObject Reloads;
    Player player;

    List<int> player1Movements;
    List<int> player2Movements;
    public List<int> playerMovements;

    List<int> player1Defences;
    List<int> player2Defences;
    public List<int> playerDefences;

    List<int> player1Atacks;
    List<int> player2Atacks;
    public List<int> playerAtacks;

    public void ClearField()
    {
        for (int i = Field.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Field.transform.GetChild(i).gameObject);
        }
    }
    void Start()
    {
        instance = this;
        TurnTxt.text = "Ход " + (PlayerTurn + 1).ToString() + "-го игрока" ;
    }
    void PlayerDefenition()
    {
        if (PlayerTurn == 0)
        {
            player = Player1;
            playerMovements = player1Movements = new List<int>();
            playerDefences = player1Defences = new List<int>();
            playerAtacks = player1Atacks = new List<int>();
        }
        else
        {
            player = Player2;
            playerMovements = player2Movements = new List<int>();
            playerDefences = player2Defences = new List<int>();
            playerAtacks = player2Atacks = new List<int>();
        }
    }

    //1-6 -- is position;
    //7 - is movement;
    //8 - is shield;
    //9 - is direction shot;
    //10 - is reload;
    
    public void EndTurn()
    {   
        ClearField();
        PlayerDefenition();
        player.UsedShield = false;
        while(player.PlayerActions.Count > 0)
        {
            if (player.PlayerActions[0] == 7)
            {
                playerMovements.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerMovements.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += Movement.actionsCost;
                
            }
            else
            if (player.PlayerActions[0] == 8)
            {
                MagicShieldBtn.interactable = true;
                playerDefences.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += MagicShield.actionsCost;
            }
            else
            if (player.PlayerActions[0] == 9)
            {
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += DirectionShot.actionsCost;
            }
            else
            if (player.PlayerActions[0] == 10)
            {
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += Reload.actionsCost;
            }
        }
        if (PlayerTurn == 0)
        {
            PlayerTurn ++;
            TurnTxt.text = "Ход " + (PlayerTurn + 1).ToString() + "-го игрока" ;
        }
        else
        {
            for (int i = 0;player1Movements.Count > 1;)
            {
                if (player1Movements[i] == 7)
                {
                    MovementDisplay(Player1, player1Movements);
                    Player1.Position = player1Movements[i+1];
                    player1Movements.RemoveAt(i+1);
                    player1Movements.RemoveAt(i);
                }
            }
            for (int i = 0;player2Movements.Count > 1;)
            {
                if (player2Movements[i] == 7)
                {
                    MovementDisplay(Player2, player2Movements);
                    Player2.Position = player2Movements[i+1];
                    player2Movements.RemoveAt(i+1);
                    player2Movements.RemoveAt(i);
                }
            }

            for (int i = 0;player1Defences.Count > 0;)
            {
                if (player1Defences[i] == 8)
                {
                    Player1.ProtectedImg.SetActive(true);
                    Player1.Protected = true;
                    player1Defences.RemoveAt(i);
                }
            }
            for (int i = 0;player2Defences.Count > 0;)
            {
                if (player2Defences[i] == 8)
                {
                    Player2.ProtectedImg.SetActive(true);
                    Player2.Protected = true;
                    player2Defences.RemoveAt(i);
                }
            }

            for (int i = 0;player1Atacks.Count > 1;)
            {
                if (player1Atacks[i] == 9)
                {
                    if (Player2.Position == player1Atacks[i+1])
                    {
                        if (Player2.Protected == false)
                        {
                            Player2.Hp -= DirectionShot.damage;
                        }
                        else
                        {
                            Player2.ProtectedImg.SetActive(false);
                            Player2.Protected = false;
                            //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                            int ShieldValue = 2;
                            Player2.Mana += ShieldValue;
                        }    
                    }
                    player1Atacks.RemoveAt(i+1);
                    player1Atacks.RemoveAt(i);
                }
                else
                if (player1Atacks[i] == 10 )
                {
                    if (gameManager.IsReloadedPosition[player1Atacks[i+1]-1] == true)
                    {
                        gameManager.IsReloadedPosition[player1Atacks[i+1]-1] = false;
                        if (Player1.Position == player1Atacks[i+1])
                        {
                            if (Player1.Protected == false)
                            {
                                Player1.Hp -= Reload.damage;
                            }
                            else
                            {
                                Player1.ProtectedImg.SetActive(false);
                                Player1.Protected = false;
                                //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                                int ShieldValue = 2;
                                Player2.Mana += ShieldValue;
                            }      
                        }
                        if (Player2.Position == player1Atacks[i+1])
                        {
                            if (Player2.Protected == false)
                            {
                                Player2.Hp -= Reload.damage;
                            }
                            else
                            {
                                Player2.ProtectedImg.SetActive(false);
                                Player2.Protected = false;
                                //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                                int ShieldValue = 2;
                                Player2.Mana += ShieldValue;
                            }      
                        }
                        Destroy(GameObject.FindGameObjectWithTag(player1Atacks[i+1].ToString()));   
                    }
                    else
                    {
                        gameManager.IsReloadedPosition[player1Atacks[i+1]-1] = true;
                        GameObject obj = Instantiate(ReloadPrefab, Vector3.zero, Quaternion.identity);
                        obj.transform.SetParent(Reloads.transform);
                        obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                        if (player1Atacks[i+1] == 1 )
                        {
                            obj.transform.localPosition =  new Vector3(-770,105,0);
                            obj.tag = "1";  
                        }
                        else if (player1Atacks[i+1] == 2)
                        {
                            obj.transform.localPosition =  new Vector3(-770,-60,0);
                            obj.tag = "2";
                        }
                        else if (player1Atacks[i+1] == 3)
                        {
                            obj.transform.localPosition =  new Vector3(-770,-220,0);
                            obj.tag = "3";
                        }
                        else if (player1Atacks[i+1] == 4)
                        {
                            obj.transform.localPosition =  new Vector3(770,105,0);
                            obj.tag = "4";
                        }
                        else if (player1Atacks[i+1] == 5)
                        {
                            obj.transform.localPosition =  new Vector3(770,-60,0);
                            obj.tag = "5";
                        }
                        else if (player1Atacks[i+1] == 6)
                        {
                            obj.transform.localPosition =  new Vector3(770,-220,0);
                            obj.tag = "6";
                        }
                    } 
                    player1Atacks.RemoveAt(i+1);
                    player1Atacks.RemoveAt(i); 
                } 
            }
            for (int i = 0;player2Atacks.Count > 1;)
            {
               if (player2Atacks[i] == 9)
                {
                    if(Player1.Position == player2Atacks[i+1])
                    {
                        if (Player1.Protected == false)
                        {
                            Player1.Hp -= DirectionShot.damage;
                        }
                        else
                        {
                            Player1.ProtectedImg.SetActive(false);
                            Player1.Protected = false;
                            //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                            int ShieldValue = 2;
                            Player1.Mana += ShieldValue;
                        }    
                           
                    }
                }
                else
                if (player2Atacks[i] == 10 )
                {
                    if (gameManager.IsReloadedPosition[player2Atacks[i+1]-1] == true)
                    {
                        gameManager.IsReloadedPosition[player2Atacks[i+1]-1] = false;
                        if (Player1.Position == player2Atacks[i+1])
                        {
                            if (Player1.Protected == false)
                            {
                                Player1.Hp -= Reload.damage;
                            }
                            else
                            {
                                Player1.ProtectedImg.SetActive(false);
                                Player1.Protected = false;
                                //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                                int ShieldValue = 2;
                                Player2.Mana += ShieldValue;
                            }      
                        }
                        if (Player2.Position == player2Atacks[i+1])
                        {
                            if (Player2.Protected == false)
                            {
                                Player2.Hp -= Reload.damage;
                            }
                            else
                            {
                                Player2.ProtectedImg.SetActive(false);
                                Player2.Protected = false;
                                //In the future, each player will have their own spell upgrades, and it will be possible to change the parameter of mana received from the shield. For now, I'll just leave it like this, so that later it will be clear where to change.
                                int ShieldValue = 2;
                                Player2.Mana += ShieldValue;
                            }      
                        }
                        Destroy(GameObject.FindGameObjectWithTag(player2Atacks[i+1].ToString()));
                    }
                    else
                    {
                        gameManager.IsReloadedPosition[player2Atacks[i+1]-1] = true;
                        GameObject obj = Instantiate(ReloadPrefab, Vector3.zero, Quaternion.identity);
                        obj.transform.SetParent(Reloads.transform);
                        obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                        
                        if (player2Atacks[i+1] == 1 )
                        {
                            obj.transform.localPosition =  new Vector3(-770,105,0);
                            obj.tag = "1";  
                        }
                        else if (player2Atacks[i+1] == 2)
                        {
                            obj.transform.localPosition =  new Vector3(-770,-60,0);
                            obj.tag = "2";
                        }
                        else if (player2Atacks[i+1] == 3)
                        {
                            obj.transform.localPosition =  new Vector3(-770,-220,0);
                            obj.tag = "3";
                        }
                        else if (player2Atacks[i+1] == 4)
                        {
                            obj.transform.localPosition =  new Vector3(770,105,0);
                            obj.tag = "4";
                        }
                        else if (player2Atacks[i+1] == 5)
                        {
                            obj.transform.localPosition =  new Vector3(770,-60,0);
                            obj.tag = "5";
                        }
                        else if (player2Atacks[i+1] == 6)
                        {
                            obj.transform.localPosition =  new Vector3(770,-220,0);
                            obj.tag = "6";
                        }
                    } 
                    player2Atacks.RemoveAt(i+1);
                    player2Atacks.RemoveAt(i); 
                }
            }
            PlayerTurn --;
            TurnTxt.text = "Ход " + (PlayerTurn + 1).ToString() + "-го игрока" ;
            Player1.UpdateHP();
            Player2.UpdateHP();
            Player1.UpdateMana();
            Player2.UpdateMana();
        }
        

        if(Player1.Hp <= 0 && Player2.Hp <= 0)
        {
            Result.SetActive(true);
            ResultTxt.text = "Ничья!";
            TieSprite.SetActive(true);
        }
        else
        {
            if(Player1.Hp <= 0)
            {
                Result.SetActive(true);
                ResultTxt.text = "Второй игрок победил!";
            }
            else if(Player2.Hp <= 0)
            {
                Result.SetActive(true);
                ResultTxt.text = "Первый игрок победил!";
            }
        }
        instance = this;
    }

    public void MovementDisplay(Player player, List<int> playerMovements)
    { 
        if (playerMovements[1] == 1 )
                {
                    player.transform.localPosition =  new Vector3(-620,110,0);   
                }
                else if (playerMovements[1] == 2)
                {
                    player.transform.localPosition =  new Vector3(-620,-60,0);
                }
                else if (playerMovements[1] == 3)
                {
                    player.transform.localPosition =  new Vector3(-620,-220,0);
                }
                else if (playerMovements[1] == 4)
                {
                    player.transform.localPosition =  new Vector3(620,110,0);
                }
                else if (playerMovements[1] == 5)
                {
                    player.transform.localPosition =  new Vector3(620,-60,0);
                }
                else if (playerMovements[1] == 6)
                {
                    player.transform.localPosition =  new Vector3(620,-220,0);
                }
    }
}
