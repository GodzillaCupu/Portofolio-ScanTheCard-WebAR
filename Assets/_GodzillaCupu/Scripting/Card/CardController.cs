using System;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardDataHandler data;
    public CardVisualComponents visualComponents;

    void OnEnable()
    {
        data.InitializeData();
        visualComponents.UpdateCardVisuals(data.currentCard);
    }
}
