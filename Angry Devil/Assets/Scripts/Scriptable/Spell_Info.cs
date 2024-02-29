using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NEW Spell Info", menuName = "Spell Info/New Spell Info")]
public class Spell_Info : ScriptableObject
{
    public GameObject spellPrefab;
    public float spellFrequency;
}
