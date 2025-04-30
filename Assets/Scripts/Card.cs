using UnityEngine;
using Random = UnityEngine.Random;

public class Card : CardBase
{
    [SerializeField] private Sprite[] cardSprites;

    protected override void SetCardType()
    {
        spriteRenderer.sprite = cardSprites[Random.Range(0, cardSprites.Length)];
    }
}
