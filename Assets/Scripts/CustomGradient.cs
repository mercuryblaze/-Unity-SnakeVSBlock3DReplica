using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGradient : MonoBehaviour
{
    public Block Block;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start()
    {
        Block = gameObject.GetComponent<Block>();
        gradient = new Gradient();

        colorKey = new GradientColorKey[2];

        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.blue;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    private void Update()
    {
        var blockRenderer = Block.GetComponent<Renderer>();

        if (Block.Hitpoints <= 10 && Block.Hitpoints >= 8)
            blockRenderer.material.SetColor("_Color", gradient.Evaluate(0f));
        else if (Block.Hitpoints <= 7 && Block.Hitpoints >= 6)
            blockRenderer.material.SetColor("_Color", gradient.Evaluate(0.2f));
        else if (Block.Hitpoints <= 5 && Block.Hitpoints >= 4)
            blockRenderer.material.SetColor("_Color", gradient.Evaluate(0.5f));
        else if (Block.Hitpoints <= 3 && Block.Hitpoints >= 2)
            blockRenderer.material.SetColor("_Color", gradient.Evaluate(0.8f));
        else
            blockRenderer.material.SetColor("_Color", gradient.Evaluate(1f));
    }
}
