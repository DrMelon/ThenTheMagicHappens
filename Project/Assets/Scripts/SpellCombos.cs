using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// The SpellCombos class is static; it only exists in non-initialized form.
// It's basically a dictionary of spell combos: 
// Combos are each a string array.
// Valid combo entries are, for the elements, F, W, E, A, and the multikey combinations FW, FE, FA etc
// Note that the multikey combinations need not be written twice here, as that is handled in combo base's lookup logic.
//
// 
//


namespace Tragic
{
    public struct SpellCombo
    {
        public string[] spell_input;
        public int spell_id;
        public string spell_name;
    }
    public static class SpellCombos
    {
       

        public static List<SpellCombo> allCombos;

        public static void GenerateSpells() // Call this once at startup.
        {
            allCombos = new List<SpellCombo>();
            int spellID = 0;
            AddSpell("COMBO NUMBER WAN", new string[] { "F", "W" }, spellID++);
            AddSpell("COMBO NUMBER TOO", new string[] { "F", "W", "F" }, spellID++);
            


        }

        public static void AddSpell(string spell_name, string[] spell_input, int id)
        {
            SpellCombo newCombo = new SpellCombo();
            newCombo.spell_input = spell_input;
            newCombo.spell_id = id;
            newCombo.spell_name = spell_name;
            allCombos.Add(newCombo);
        }

    }
}