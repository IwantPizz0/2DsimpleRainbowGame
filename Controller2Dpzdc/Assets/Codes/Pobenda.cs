using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlockColors : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> groundTiles;
    [SerializeField] private PlayerController playerController;
    //[SerializeField] private Color denyColor;

    private void Update()
    {
        CheckTilesCollor();
    }


    private void CheckTilesCollor()
    {

        for (int i = 0; i < groundTiles.Count; i++)
        {

            if (groundTiles[i].color != playerController.accentColor)
                return;

        }

      
        Debug.Log("WIN!");
    }
}