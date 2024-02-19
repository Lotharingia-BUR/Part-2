using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cauldron : MonoBehaviour
{
    Collider2D cb;
    int potionID;
    /*int desiredPotionID = 2121;*/
    public List<int> desiredPotionID;
    public GameObject display;

    private void Start()
    {
        cb = GetComponent<Collider2D>();

        //create list
        SendMessage("createList");
    }

    public void createList()
    {
        //display randomized potion;
        for (int i = 0; i < 4; i++)
        {
            desiredPotionID[i] = Random.Range(1, 3);
        }
        display.SendMessage("ShowList", desiredPotionID);
    }

    public void Grab(GameObject player)
    {
        if (cb.IsTouching(player.GetComponent<Collider2D>()))
        {
            player.SendMessage("Deposit", gameObject);
        }

    }

    public void addIngrediant(int ID)
    {

        if (desiredPotionID.Contains(ID))
        {
            desiredPotionID[desiredPotionID.IndexOf(ID)] = 0;
        } else
        {
            //game over
            SceneManager.LoadScene(2);
        }
        /*for(int i = 0; i < desiredPotionID.Capacity; i++)
        {
            Debug.Log(desiredPotionID[i]);
        }*/
        /*potionID = potionID * 10 + ID;

        if (potionID > 999)
        {
            if (potionID == desiredPotionID)
            {
                Debug.Log("win");
            } else
            {
                Debug.Log("you made an error" + potionID);
            }
        } */
    }
}
