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
    int num = 0;

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
            num++;
            if(num == 4)
            {
                //win
                SceneManager.LoadScene(3);
            }
        } else
        {
            //game over
            SceneManager.LoadScene(2);
        }
    }
}
