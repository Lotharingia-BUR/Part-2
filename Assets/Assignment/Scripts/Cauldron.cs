using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    Collider2D cb;
    int potionID;
    int desiredPotionID = 2121;
    public GameObject display;

    private void Start()
    {
        cb = GetComponent<Collider2D>();
        display.SendMessage("ShowList", desiredPotionID);

    }

    public void Grab(GameObject player)
    {
        if (cb.IsTouching(player.GetComponent<Collider2D>()))
        {
            Debug.Log("Deposit");
            player.SendMessage("Deposit", gameObject);
        }
    }

    public void addIngrediant(int ID)
    {
        potionID = potionID * 10 + ID;
        Debug.Log(potionID);

        if (potionID > 999)
        {
            if (potionID == desiredPotionID)
            {
                Debug.Log("win");
            } else
            {
                Debug.Log("you made an error" + potionID);
            }
        } 
    }
}
