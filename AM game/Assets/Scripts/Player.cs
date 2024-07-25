using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Mana;
    public int Hp;
    public int Position;
    public int ActionCount;
    public bool Protected;
    public List<int> PlayerActions;
    public TextMeshProUGUI PlayerHPtxt;
    public TextMeshProUGUI PlayerManatxt;
    public GameObject Field;

    //1-6 -- is position;
    //7 - is movement;
    //8 - is shield;
    //9 - is direction shot;
    //10 - is reload;

    public Player(int mana, int hp, int position, int actionCount)
    {
       Mana = mana;
       Hp = hp;
       Position = position;
       ActionCount = actionCount;
       Protected = false;
       PlayerActions = new List<int>();
    }

    public void UpdateHP()
    {
        PlayerHPtxt.text = Hp.ToString();
    }

        public void UpdateMana()
    {
        PlayerManatxt.text = Mana.ToString();
    }
    public void AddAction(int action, GameObject actionPrefab, string spritePath)
    {
        PlayerActions.Add(action);
    
        GameObject obj = Instantiate(actionPrefab, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(Field.transform); // Устанавливаем родителя (в данном случае текущий объект)
        obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        // Назначаем спрайт дочернему объекту с именем "ActionImg"
        Transform actionImg = obj.transform.Find("ActionImg");
        if (actionImg != null)
        {
            Image image = actionImg.GetComponent<Image>();
            if (image != null)
            {
                // Загружаем спрайт из ресурсов
                Sprite sprite = Resources.Load<Sprite>(spritePath);
                if (sprite != null)
                {
                    image.sprite = sprite;
                }
                else
                {
                    Debug.LogError("Sprite not found at path: " + spritePath);
                }
            }
            else
            {
                Debug.LogError("Image component not found on ActionImg object.");
            }
        }
        else
        {
            Debug.LogError("ActionImg object not found as a child of the instantiated prefab.");
        }
    

    }
    public void RemoveAction(int number)
    {
        PlayerActions.RemoveAt(number);
        Destroy(Field.transform.GetChild(number).gameObject);
    }
}
