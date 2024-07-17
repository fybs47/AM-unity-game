using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionChoosed : MonoBehaviour
{
    public GameObject DirectionSelectionWin;
     public Button FirstPosBtn;
     public Button SecondPosBtn;
     public Button ThirdPosBtn;
     public Button FourthPosBtn;
     public Button FifthPosBtn;
     public Button SixthPosBtn;

     public void ChooseDirection()
     {
        FirstPosBtn.interactable = false;
        SecondPosBtn.interactable = false;
        ThirdPosBtn.interactable = false;
        FourthPosBtn.interactable = false;
        FifthPosBtn.interactable = false;
        SixthPosBtn.interactable = false;

        DirectionSelectionWin.SetActive(false);
     }
}
