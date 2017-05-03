using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager {

    private Player player;

    public PlayerManager(Player player)
    {
        this.player = player;
    }
}
