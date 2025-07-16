using System;
using UnityEngine;
using TMPro;

[Serializable]
public class CardVisualComponents
{
    [Serializable]
    public enum ShaderType
    {
        ShaderGraph,
        ShaderLab,
    }

    public ShaderType shaderType = ShaderType.ShaderLab;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardLossesText;
    public TextMeshProUGUI cardYearText;
    public Renderer cardIconRenderer;
    public Renderer artworkBG_Renderer;
    public Renderer borderBG_Renderer;

    public void UpdateText(TextMeshProUGUI _targetText, string data) => _targetText.text = data;

    public void UpdateImage(Renderer _targetRenderer, Texture2D newTexture)
    {
        if (newTexture == null || _targetRenderer == null)
        {
            Debug.LogWarning("New Texture is null. Cannot set texture.");
            return;
        }

        _targetRenderer.material.mainTexture = newTexture;
    }

    public void UpdateCardVisuals(CardData _data)
    {
        if (_data == null)
        {
            Debug.LogWarning("Current card data is null. Please initialize the card data first.");
            return;
        }

        // Update Text Components
        UpdateText(cardNameText, _data.GetCardName());
        UpdateText(cardLossesText, _data.GetCardTottalLosses());
        UpdateText(cardYearText, _data.GetYear());

        //Update Image Components
        UpdateImage(cardIconRenderer, _data.GetIcon()?.texture);
        UpdateImage(borderBG_Renderer, _data.GetBorderBackground()?.texture);
        UpdateImage(artworkBG_Renderer, _data.GetArtworkBackground()?.texture);
    }
}
