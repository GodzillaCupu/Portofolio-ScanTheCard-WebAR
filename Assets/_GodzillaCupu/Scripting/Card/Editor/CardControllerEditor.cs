using UnityEngine;
using System;
using UnityEditor;

[CustomEditor(typeof(CardController))]
public class CardControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CardController cardController = (CardController)target;

        cardController.isTestMode = EditorGUILayout.Toggle("Test Mode", cardController.isTestMode);
        using(var group = new EditorGUILayout.FadeGroupScope(cardController.isTestMode ? 1 : 0))
        {
            if (group.visible)
            {
        
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

        cardController.cardVisualComponents.shaderType = EditorGUILayout.Toggle("Using Shader Graph", cardController.cardVisualComponents.shaderType == CardController.CardVisualComponents.ShaderType.ShaderGraph) 
            ? CardController.CardVisualComponents.ShaderType.ShaderGraph 
            : CardController.CardVisualComponents.ShaderType.ShaderLab ;

        if (cardController.cardVisualComponents.shaderType == CardController.CardVisualComponents.ShaderType.ShaderLab)
        {
            cardController.cardVisualComponents.artworkBG_Renderer =
                (Renderer)EditorGUILayout.ObjectField("Card Artwork Background Renderer", cardController.cardVisualComponents.artworkBG_Renderer, typeof(Renderer), true);
            cardController.cardVisualComponents.borderBG_Renderer =
                (Renderer)EditorGUILayout.ObjectField("Card Border Background Renderer", cardController.cardVisualComponents.borderBG_Renderer, typeof(Renderer), true);
        }
        else
        {
            cardController.cardVisualComponents.artworkBG_Renderer =
                (Renderer)EditorGUILayout.ObjectField("Card Artwork Renderer", cardController.cardVisualComponents.artworkBG_Renderer, typeof(Renderer), true);
            cardController.cardVisualComponents.borderBG_Renderer =
                (Renderer)EditorGUILayout.ObjectField("Card Border Renderer", cardController.cardVisualComponents.borderBG_Renderer, typeof(Renderer), true);
        }
        base.OnInspectorGUI();
    }
}
