using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    List<SpriteRenderer> displaySprites;
    SpriteRenderer display;
    public List<Sprite> sprites;

    public void ShowList(int ID)
    {
        string potionID = ID.ToString();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            display = child.GetComponent<SpriteRenderer>();
            Debug.Log(potionID[i]);
            // -48 char value
            display.sprite = sprites[(int)potionID[i] - 48];
            /*sprites[potionID[i]] = transform.GetChild(i).gameObject..sprite; */
        }
    }
}
