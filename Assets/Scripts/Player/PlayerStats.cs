using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int power;// players strength / mele attack power / modified by weapons, items, level
    public int HP;// player life / modified by level, items
    public int maxHP;// max hp to keep life in check
    public int stealth;// stealth leve 0-100 / level of stealth, ability to hide / modified by weapons, items
    public int defense;// damage prevention / modified by level, items
    public int luck;// abilty to find rare items / modified by items, level
    public int charm;// ability of player to merchant well / modified by items, level
    public int mind;// player intelligence / spell attack power / modified by spells, items, level

    private int level;// player exp milestone / modifies stats
    private int exp;// player experience / player collects to level by killong enemies
    private int nextLevelExp;// the point where player reaches level milestone / modify by stored array as player levels


}
