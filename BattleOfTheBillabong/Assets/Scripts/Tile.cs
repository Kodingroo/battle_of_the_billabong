using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] tileGraphics;

    public float hoverAmount;

    public LayerMask obstacleLayer;

    public Color highlightedColor;
    public bool isWalkable;
    GameMaster gm;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int randTile = Random.Range(0, tileGraphics.Length);
        rend.sprite = tileGraphics[randTile];

        gm = FindObjectOfType<GameMaster>();
    }

    private void OnMouseEnter() 
    {
        if(isClear() == true) {
            transform.localScale += Vector3.one * hoverAmount;
        }
    }

    private void OnMouseExit() 
    {
        if (isClear() == true)  {
            transform.localScale -= Vector3.one * hoverAmount;
        }
    }

    public bool isClear() // does this tile have an obstacle on it. Yes or No?
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.2f, obstacleLayer);
        if (col != null)
        {
            return false;
        }
        else {
            return true;
        }
    }

    public void Highlight() {
        rend.color = highlightedColor;
        isWalkable = true;
    }

    public void Reset() {
        rend.color = Color.white;
        isWalkable = false;
    }

    private void OnMouseDown() {
        if(isWalkable && gm.selectedUnit != null) {
            gm.selectedUnit.Move(this.transform.position);
        }
    }
}
