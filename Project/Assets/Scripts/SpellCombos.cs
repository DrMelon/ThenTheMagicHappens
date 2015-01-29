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
			// F, W, E, A,
            allCombos = new List<SpellCombo>();
            int spellID = 0;

            AddSpell("1ST COMBO", new string[] { "F", "W" }, spellID++);
            AddSpell("2ND COMBO", new string[] { "F", "E" }, spellID++);
            AddSpell("3RD COMBO", new string[] { "W", "E", "F" }, spellID++);
            AddSpell("4TH COMBO", new string[] { "A", "E", "F" }, spellID++);
            AddSpell("5TH COMBO", new string[] { "A", "F", "W", "E" }, spellID++);
            AddSpell("6TH COMBO", new string[] { "E", "W", "F", "E" }, spellID++);
            AddSpell("7TH COMBO", new string[] { "A", "A", "E", "A", "W" }, spellID++);
            AddSpell("8TH COMBO", new string[] { "W", "A", "F", "E", "W" }, spellID++);
            AddSpell("9TH COMBO", new string[] { "W", "E", "A", "E", "E", "F" }, spellID++); // 420
            AddSpell("10TH COMBO", new string[] { "W", "F", "A", "E", "A", "F" }, spellID++); // Mega



			//ADD SPELLS HERE!


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