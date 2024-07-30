using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool[] IsReloadedPosition { get; set; }

    void Start()
    {
        Instance = this;
        IsReloadedPosition = new bool[6];
        for (int i = 0; i < IsReloadedPosition.Length;i++) 
        {
            IsReloadedPosition[i] = false;
        }
    }
}
