using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNextBox : MonoBehaviour
{
    private Image piece;
    public Sprite[] nextStates = new Sprite[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprites(List<string> upcomingPieces)
    {
        for (int i = 0; i < 4; i++)
        {
            piece = GameObject.Find("Piece" + i).GetComponent<Image>();
            piece.sprite = nextStates[GetPieceNumber(upcomingPieces[i])];
        }
    }
    int GetPieceNumber(string colour)
    {
        switch (colour)
        {
            case "Red":
                return 1;
            case "Orange":
                return 2;
            case "Yellow":
                return 3;
            case "Green":
                return 4;
            case "Cyan":
                return 5;
            case "Blue":
                return 6;
            case "Purple":
                return 7;
            default:
                return 0;
        }
    }
}
