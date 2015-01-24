using UnityEngine;
using System.Collections;


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
    public static class SpellCombos
    {

        public static string[] SPELL_TEST_SINGLEKEYS = { "F", "W" };

        public static string[] SPELL_TEST_DOUBLEKEYS = { "WE", "F" };

    }
}