using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] public CardScriptableObject cardData;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI numText;
    [SerializeField] TextMeshProUGUI nameText;


    private void Start()
    {
        image.sprite = cardData.graphic;
        numText.text = cardData.numValue.ToString();
        nameText.text = cardData.cardName;
    }



}
