using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShooterItems : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    [SerializeField]
    private ItemRarity itemRarity;

    [SerializeField]
    private ItemTag itemTag;

    [SerializeField]
    private Sprite Sprite;

    [SerializeField]
    private int life;

    [SerializeField]
    private int scoreBonus;

    public enum ItemType
    {
        ENNEMY,

        GREENBONUS,

        BLUEBONUS,

        REDBONUS,

        SHIELD
    }

    public enum ItemRarity
    {
        COMMON,

        FINE,

        RARE,

        LEGENDARY
    }

    public enum ItemTag
    {
        MALUS,

        BONUS,

        POWERUP
    }

    public int getLife()
    {
        return life;
    }

    public int getScoreBonus()
    {
        return scoreBonus;
    }

    public ItemType getType()
    {
        return this.itemType;
    }

    public ItemRarity getRarity()
    {
        return this.itemRarity;
    }
}
