using UnityEngine;
using System.Collections;
using System;
using Tragic;

// Jordan Brown
// @drmelon
// 24/01/15 19:00
// #GGJ15

// In collaboration with
// @johnjoemcbob
// @_Inu_
// @MaxWrighton

// Allow for arrays of keys which need to pressed in that order
// Allow for multiple keys required to be held down at once
// Store the last 10-20 key presses in an array to be checked against combos as new keys are added
// Queue format (when there are too many keys, it will move every key 1 towards the array origin)

// Keys;
//      Fire - Key 0
//      Water - Key 1
//      Earth - Key 2
//      Air - Key 3
//      Move left
//      Move right


public class ComboBase : MonoBehaviour
{
    public string[] ValidKeys; // See keys above (these are defined in the editor)
    private bool keysCombined;

    // Horrible string literals, representing together-key-combos
    public  string KEY_FIRE;
    public  string KEY_WATER;
    public string KEY_EARTH;
    public  string KEY_AIR;
    public string TWOKEYS_FIREWATER;
    public string TWOKEYS_FIREEARTH;
    public  string TWOKEYS_FIREAIR;
    public  string TWOKEYS_WATERFIRE;
    public  string TWOKEYS_WATEREARTH;
    public  string TWOKEYS_WATERAIR;
    public  string TWOKEYS_EARTHFIRE;
    public  string TWOKEYS_EARTHWATER;
    public  string TWOKEYS_EARTHAIR;
    public  string TWOKEYS_AIRFIRE;
    public  string TWOKEYS_AIRWATER;
    public  string TWOKEYS_AIREARTH;

    // RecentKeys represents keypresses that have just been made;
    // PressedKeys is the list of keys to be checked for a combo, as it has been processed to group combined presses together.
    private Queue RecentKeys;
    private Queue PressedKeys;
    private int currentkey = 0;

    private static int maxkeys = 10;

    


	void Start()
    {
        keysCombined = false;
        // Dimension array
        PressedKeys = new Queue(maxkeys);
        RecentKeys = new Queue(maxkeys);
        {
            // Initialize array elements to blank
            
            for (int key = 0; key < maxkeys; key++)
            {
                KeyCommand newKey = new KeyCommand();
                KeyCommand blankKey = new KeyCommand();

                newKey.keyPressed = "";
                newKey.framePressed = 0;

                blankKey.keyPressed = "";
                blankKey.framePressed = 0;

                RecentKeys.Enqueue(newKey); // add blank key to keyqueue
                PressedKeys.Enqueue(blankKey);
            }
             
        }


        // Set up keys and combos
        if(ValidKeys.Length > 0)
        {
            KEY_FIRE = ValidKeys[0];
            KEY_WATER = ValidKeys[1];
            KEY_EARTH = ValidKeys[2];
            KEY_AIR = ValidKeys[3];

            // two-key combinations!

            TWOKEYS_FIREWATER   = KEY_FIRE + KEY_WATER;
            TWOKEYS_FIREEARTH   = KEY_FIRE + KEY_EARTH;
            TWOKEYS_FIREAIR     = KEY_FIRE + KEY_AIR;

            TWOKEYS_WATERFIRE   = KEY_WATER + KEY_FIRE;
            TWOKEYS_WATEREARTH  = KEY_WATER + KEY_EARTH;
            TWOKEYS_WATERAIR    = KEY_WATER + KEY_AIR;

            TWOKEYS_EARTHFIRE   = KEY_EARTH + KEY_FIRE;
            TWOKEYS_EARTHWATER  = KEY_EARTH + KEY_WATER;
            TWOKEYS_EARTHAIR    = KEY_EARTH + KEY_AIR;

            TWOKEYS_AIRFIRE     = KEY_AIR   + KEY_FIRE;
            TWOKEYS_AIRWATER    = KEY_AIR   + KEY_WATER;
            TWOKEYS_AIREARTH    = KEY_AIR   + KEY_EARTH;
        }


        // Generate all the spells.
        SpellCombos.GenerateSpells();

    }

	void Update()
    {
        // Ensure ValidKeys have been set in the editor
        if (ValidKeys.Length > 0)
        {
            // Check each validkey
            foreach (string key in ValidKeys)
            {
                // If the key is down, add to the array
                if (Input.GetKeyDown(key))
                {
                    // Push all the other keys back one 
                    


                    // Store what was pressed, and when.
                    KeyCommand newKey = new KeyCommand();
                    newKey.keyPressed = key;
                    newKey.framePressed = Time.renderedFrameCount;
                    newKey.combined = false;
                    newKey.pressed = false;

                    if (RecentKeys.Count > 0)
                    {
                        RecentKeys.Dequeue();
                    }
                    RecentKeys.Enqueue(newKey);

                    keysCombined = false;
               
                   
                }
            }
        }


        
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CastSpell();
        }
        
        



        



	}

    public void ResetQueues()
    {
        RecentKeys.Clear();
        PressedKeys.Clear();
        for (int key = 0; key < maxkeys; key++)
        {
            KeyCommand newKey = new KeyCommand();
            KeyCommand blankKey = new KeyCommand();

            newKey.keyPressed = "";
            newKey.framePressed = 0;
            newKey.pressed = false;

            blankKey.keyPressed = "";
            blankKey.framePressed = 0;
            blankKey.pressed = false;

            RecentKeys.Enqueue(newKey); // add blank key to keyqueue
            PressedKeys.Enqueue(blankKey);
        }
    }

    public void CombineKeypresses()
    {
        // Attempt to combine keypresses into combined keypresses.
        PressedKeys.Clear();
        object[] checkArray = RecentKeys.ToArray();
        if (checkArray.Length > 0)
        {
            KeyCommand prevKeyCmd = (KeyCommand)checkArray[0];
            for (int key = 0; key < checkArray.Length; key++)
            {
                KeyCommand currentCheckKey = (KeyCommand)checkArray[key];
                KeyCommand combinedKey = new KeyCommand();

                // Check to see if the command was entered during the 15 frames of leniency
                if ((Math.Abs(currentCheckKey.framePressed - prevKeyCmd.framePressed) <= 7) &&
                    (currentCheckKey.keyPressed != prevKeyCmd.keyPressed))
                {
                    // Combine these keys.
                    combinedKey.keyPressed = prevKeyCmd.keyPressed + currentCheckKey.keyPressed;
                    combinedKey.framePressed = currentCheckKey.framePressed;
                    currentCheckKey.combined = true;
                    
                    
                    combinedKey.combined = true;
                    combinedKey.pressed = true;
                }
                else
                {
                    combinedKey = currentCheckKey;
                    
                }
                
                PressedKeys.Enqueue(combinedKey);
                

                prevKeyCmd = currentCheckKey;

            }
            
        }

        keysCombined = true;
    }

    public int CastSpell() //call this when you want to try casting after building up inputs
    {
        // Attempt to combine keys.
        if (RecentKeys.Count > 0 && keysCombined == false)
        {
            CombineKeypresses();

        }

        // Check all combos
        int didCombo = -1;
        foreach (SpellCombo SC in SpellCombos.allCombos)
        {
            didCombo = CheckMatchingCombo(SC);
			if(didCombo > -1)
			{
				break; // don't keep trying combos if we found one!
			}
        }


        if (didCombo > -1)
        {
            // WOMBO COMBO
            print("DID COMBO: " + didCombo.ToString());
        }


        // Tried to cast spell, reset queue
        ResetQueues();

        return didCombo;
    }

    public int CheckMatchingCombo(SpellCombo checkSpell)
    {
        // Print Commands
        PrintPressedKeys();

        string[] CheckCombo = checkSpell.spell_input;

        // Convert combo dictionary keys into ValidKey keys
        string[] newCombo = new string[CheckCombo.Length];
        for (int comboLetter = 0; comboLetter < CheckCombo.Length; comboLetter++)
        {
            
            for (int comboLetterLetter = 0; comboLetterLetter < CheckCombo[comboLetter].Length; comboLetterLetter++)
            {
                if (CheckCombo[comboLetter][comboLetterLetter] == "F"[0])
                {
                    newCombo[comboLetter] += KEY_FIRE;
                }
                if (CheckCombo[comboLetter][comboLetterLetter] == "W"[0])
                {
                    newCombo[comboLetter] += KEY_WATER;
                }
                if (CheckCombo[comboLetter][comboLetterLetter] == "E"[0])
                {
                    newCombo[comboLetter] += KEY_EARTH;
                }
                if (CheckCombo[comboLetter][comboLetterLetter] == "A"[0])
                {
                    newCombo[comboLetter] += KEY_AIR;
                }
            }
        }
      
        
        // Turn pressedkeys into a string array
        object[] pressedKeysArray = PressedKeys.ToArray();
        bool stillMatches = true;
        bool firstMatch = false;
        int whatPositionInPressedKeysMatch = 0;

        if(newCombo.Length > pressedKeysArray.Length)
        {
            // Doesn't match combo
            return -1;
        }

        // Need to match first character of combo with something in pressed keys array.
        for (int i = 0; i < pressedKeysArray.Length; i++)
        {
            KeyCommand keyP = (KeyCommand)pressedKeysArray[i];
            // cycle through, checking against the current combo until we make our first match
            if (keyP.keyPressed == newCombo[0])
            {
                firstMatch = true;
                whatPositionInPressedKeysMatch = i;
                break;
            }
        }

        // If there is no first match or if the length of the combo is longer than the input buffer's remaining space, return.
        if (firstMatch == false || whatPositionInPressedKeysMatch + newCombo.Length > pressedKeysArray.Length)
        {
            return -1;
        }

        for(int i = whatPositionInPressedKeysMatch; i < pressedKeysArray.Length; i++)
        {
            KeyCommand keyP = (KeyCommand)pressedKeysArray[i];
            int newComboLoc = i - whatPositionInPressedKeysMatch;
            if(newComboLoc < 0 || newComboLoc > newCombo.Length-1)
            {
                return -1;
            }
            if (keyP.keyPressed == newCombo[newComboLoc])
            {
                stillMatches = true;
            }
            else
            {
                stillMatches = false;
                break;
            }
        }
        
        if(!stillMatches)
        {
            // Matching failed in mid-combo check.
            return -1;
        }

        ////// All checks succeeded! COMBO IS HIT!!!
        print("PERFORMED COMBO! ");
        return checkSpell.spell_id;

        





    }


    public void PrintPressedKeys()
    {
        string outs = "[";
        foreach(KeyCommand k in PressedKeys)
        {
            outs += k.keyPressed + ",";
        }
        outs += "]";
        print(outs);
    }
    
    
    
}

// The KeyCommand class represents a key pressed at a certain frame.
// However, a KeyCommand can also be multiple keys: 
// the keyPressed string can read "ab" or "xy" etc, and represents those keys having been pushed at a similar time.
// Note; when checking for a key combination, make sure to check for "ab" AND "ba" - keys will not be sorted automatically.

public class KeyCommand
{
    public string keyPressed;
    public int framePressed;
    public bool combined;
    public bool pressed;

}
