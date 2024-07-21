using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public static TurnController instance;
    public Button MagicShield;
    public Player Player1;
    public Player Player2;
    public int PlayerTurn;
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

    void Start()
    {
        instance = this;
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
        PlayerDefenition();
        while(player.PlayerActions.Count > 0)
        {
            if (player.PlayerActions[0] == 7)
            {
                playerMovements.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerMovements.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += 3;
            }
            else
            if (player.PlayerActions[0] == 8)
            {
                MagicShield.interactable = true;
                playerDefences.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += 2;
                player.Mana += 2;
            }
            else
            if (player.PlayerActions[0] == 9)
            {
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += 2;
                player.Mana += 2;
            }
            else
            if (player.PlayerActions[0] == 10)
            {
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                playerAtacks.Add(player.PlayerActions[0]);
                player.PlayerActions.RemoveAt(0);
                player.ActionCount += 2;
                player.Mana += 1;
            }
        }
        if (PlayerTurn == 0)
        {
            PlayerTurn ++;
        }
        else
        {
            PlayerTurn --;
        }
        instance = this;
    }
}
