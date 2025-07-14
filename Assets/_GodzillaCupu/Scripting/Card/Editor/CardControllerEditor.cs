using UnityEngine;
using System;
using UnityEditor;

[CustomEditor(typeof(CardController))]
public class CardControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CardController cardController = (CardController)target;

        if (GUILayout.Button("Initialize Random Card"))
        {
            cardController.InitializeRandomCard();
        }

        if (GUILayout.Button("Initialize First Card"))
        {
            cardController.InitializeFirstCard();
        }

        if (GUILayout.Button("Update Card Visuals"))
        {
            cardController.UpdateCardVisuals();
        }

        if (GUILayout.Button("Set Card Datas"))
        {
            cardController.InitializeCardDatas();
        }

        if (GUILayout.Button("Set Ordered Card Datas"))
        {
            cardController.SetOrderedCardData(cardController.cardCollections.cardDatas);
        }

    }
}
