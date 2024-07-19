using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1 = new Player(30,30,2,5);
    public Player player2 = new Player(30,30,5,5);
    public int PlayerTurn;

    public void PlayerDefinition(Player player)
    {
        if(PlayerTurn == 0)
        {
            player = player1;
        }
        else
        {
            player = player2;
        }
    }
}
