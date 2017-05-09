using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] healthSprites;

    public Image healthBarUI;

    private Player player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update ()
    {
        int healthSpriteIndex = ( (int) Mathf.Round(player.health / (100 / healthSprites.Length)) ) - 1;

        // Safe
        if (healthSpriteIndex > -1 && healthSpriteIndex < healthSprites.Length)
        {
            healthBarUI.sprite = healthSprites[healthSpriteIndex];
        }
    }
}
