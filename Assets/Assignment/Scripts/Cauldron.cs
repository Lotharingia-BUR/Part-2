using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    Collider2D cb;
    float potionID;
    float desiredPotionID;

    private void Start()
    {
        cb = GetComponent<Collider2D>();

        if (potionID > 999)
        {
            if (potionID == desiredPotionID)
            {
                Debug.Log("win");
            } else
            {
                Debug.Log("you made an error");
            }
        } 
    }

    public void Grab(GameObject player)
    {
        if (cb.IsTouching(player.GetComponent<Collider2D>()))
        {
            Debug.Log("Deposit");
            player.SendMessage("deposit", gameObject);
        }
    }

    public void addIngrediant(int ID)
    {
        potionID = potionID * 10 + ID;
    }
}
