using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHoldBox : MonoBehaviour
{
    private Image holdBox;
    public Sprite[] holdStates = new Sprite[8];

    // Start is called before the first frame update
    void Start()
    {
        holdBox = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite(string colour)
    {
        switch (colour)
        {
            case "Red":
                holdBox.sprite = holdStates[1];
                break;
            case "Orange":
                holdBox.sprite = holdStates[2];
                break;
            case "Yellow":
                holdBox.sprite = holdStates[3];
                break;
            case "Green":
                holdBox.sprite = holdStates[4];
                break;
            case "Cyan":
                holdBox.sprite = holdStates[5];
                break;
            case "Blue":
                holdBox.sprite = holdStates[6];
                break;
            case "Purple":
                holdBox.sprite = holdStates[7];
                break;
            default:
                holdBox.sprite = holdStates[0];
                break;
        }
    }
}
