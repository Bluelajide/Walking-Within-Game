using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Collectible
{
    public Transform playerPos;
    public Transform offscreenPos;
    public float speed;
    [SerializeField] private GameObject mapSprite;

    public Sprite emptyMap;
    public int mapCount = 1;

    private void Awake()
    {
        mapSprite.SetActive(false);
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyMap;
            GameManager.instance.ShowText("Map Acquired", 25, Color.yellow, transform.position, Vector3.up * 25, 1.0f);
            mapSprite.SetActive(true);
        }
    }
}
