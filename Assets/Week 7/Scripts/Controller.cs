using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Teammate SelectedPlayer { get; private set; }
    public static int score;
    float force = 0;
    Vector2 direction;
    public Slider chargeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedPlayer == null) return;

        if (Input.GetKey("space")) 
        {
            force = Mathf.Clamp(force + Time.deltaTime * 2, 0, 4);
            chargeSlider.value = force;
        } else if (Input.GetKeyUp("space"))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * force;
            force = 0;
            chargeSlider.value = force;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Kick(direction);
            direction = Vector2.zero;
        }
    }


    public static void SetSelectedPlayer(Teammate player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
            
        }
        SelectedPlayer = player;
        player.Selected(true);
    }
}
