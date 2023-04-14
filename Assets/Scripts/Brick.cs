using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    public int PointValue;
    private Color lightPink = new Color(0.94f, 0.43f, 0.58f, 1f);
    private Color midPink = new Color(0.8f, 0.17f, 0.37f, 1f);
    private Color darkPink = new Color(0.5f, 0.05f, 0.17f, 1f);
    Color errorColor = new Color(1f, 1f, 1f, 1f);

    void Start()
    {
        //Color the brick
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", lightPink);
                break;
            case 2:
                block.SetColor("_BaseColor", midPink);
                break;
            case 5:
                block.SetColor("_BaseColor", darkPink);
                break;
            default:
                block.SetColor("_BaseColor", errorColor);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    void Update()
    {
        // Delete the bricks at GameOver
        if (MainManager.Instance.m_GameOver == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
