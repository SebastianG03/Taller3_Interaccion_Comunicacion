using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    public Player player; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.PlayerMovement.IsActionChangeColorKeyDown())
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        sr.color = randomColor;
    }
}
