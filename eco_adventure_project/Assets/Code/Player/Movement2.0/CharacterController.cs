using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Sprite leftFacingSprite;
    public Sprite rightFacingSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            spriteRenderer.sprite = rightFacingSprite;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.sprite = leftFacingSprite;
        }
    }
}