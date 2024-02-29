using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public List<Spell_Info> playerSpells;
    Player_Unit player;
    void Start()
    {
        player = GetComponent<Player_Unit>();
        foreach (Spell_Info SI in playerSpells)
        {
            StartCoroutine(SpellRoutine(SI));
        }
    }

    IEnumerator SpellRoutine(Spell_Info v_SI)
    {
        while (player.isPlayerAlive)
        {
            yield return new WaitForSeconds(v_SI.spellFrequency);
            Instantiate(v_SI.spellPrefab, transform.position, transform.rotation);
        }
    }
}
