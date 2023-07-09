using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] List<CardScriptableObject> Cards;
    [SerializeField] Transform canvas;
    [SerializeField] Card card;

    List<Card> drawnCards = new List<Card>();

    private void Start()
    {
        Draw7();
    }

    //get 7 random cards
    public void Draw7()
    {
        ClearHand();
        Card recentlyDrawnCard;
        for (int i = 0; i < 7; i++)
        {
            recentlyDrawnCard = DrawCard();
            recentlyDrawnCard.transform.position = new Vector2((i + 1) * Screen.width / 8, 0);
        }
    }

    //destroy all cards to save memory
    void ClearHand()
    {
        foreach (Card drawnCard in drawnCards)
        {
            Destroy(drawnCard.gameObject);
        }
        drawnCards.Clear();
    }

    //return a random card
    Card DrawCard()
    {
        int rnd = Random.Range(0, Cards.Count);
        Card c = Instantiate(card, canvas);
        drawnCards.Add(c);
        c.cardData = Cards[rnd];
        return c;
    }

    //returns the num values of all held cards in an array
    public int[] Serialize()
    {
        int[] handData = new int[drawnCards.Count];
        for (int i = 0; i < drawnCards.Count; i++)
        {
            handData[i] = drawnCards[i].cardData.numValue;
            Debug.Log(drawnCards[i].cardData.numValue);
        }
        return handData;
    }

    //draw a specific set of cards from an array
    public void LoadHand(HandData handData)
    {
        ClearHand();
        for (int i = 0; i < handData.hand.Length; i++)
        {
            Card c = Instantiate(card, canvas);
            drawnCards.Add(c);
            c.cardData = Cards[handData.hand[i]];
            c.transform.position = new Vector2((i + 1) * Screen.width / 8, 0);

        }
    }
}
