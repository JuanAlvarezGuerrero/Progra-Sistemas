using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Posters : MonoBehaviour
{
    public string text = "";
    GameManager gamemanager;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gamemanager.ShowText(text);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamemanager.HideText();
        }
    }



}
