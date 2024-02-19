using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    List<SpriteRenderer> displaySprites;
    SpriteRenderer display;
    public List<Sprite> sprites;

    public void ShowList(List<int> ID)
    {
        for (int i = 0; i < 4; i++)
        {
            int id = ID[i];
            GameObject child = transform.GetChild(i).gameObject;
            display = child.GetComponent<SpriteRenderer>();
            display.sprite = sprites[(int)ID[i]];

            /*for (int i = 0; i < ID.Capacity; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                display = child.GetComponent<SpriteRenderer>();
                display.sprite = sprites[ID[i]];
            }*/
        }
    }
}
