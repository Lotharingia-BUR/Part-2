using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    public int ingrediantID = 0;
    public List<Sprite> images;
    Transform a;
    Collider2D cb;
    SpriteRenderer displaySprite;
    private void Start()
    {
        cb = GetComponent<Collider2D>();

        GameObject display = GameObject.Find(gameObject.name +"/Display");
        displaySprite = display.GetComponent<SpriteRenderer>();

        switch (ingrediantID)
        {
            case 0:
                break;
            case 1:
                displaySprite.sprite = images[ingrediantID];
                break;
        }
    }
    public void Grab(GameObject player)
    {
        if (cb.IsTouching(player.GetComponent<Collider2D>()))
        {
            Debug.Log("selected" + ingrediantID);
            player.SendMessage("Grabbed", ingrediantID);
        } else
        {
            Debug.Log("blank");
        }
    }
}
