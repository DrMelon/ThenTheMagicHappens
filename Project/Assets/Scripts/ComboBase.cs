using UnityEngine;
using System.Collections;
using System;

// Matthew Cormack
// @johnjoemcbob
// 24/01/15 00:05
// #GGJ15

// In collaboration with
// @DrMelon
// @_Inu_
// @MaxWrighton

// Allow for arrays of keys which need to pressed in that order
// Allow for multiple keys required to be held down at once
// Store the last 10-20 key presses in an array to be checked against combos as new keys are added
// Queue format (when there are too many keys, it will move every key 1 towards the array origin)

// Keys;
//      Fire
//      Water
//      Earth
//      Air
//      Move left
//      Move right


public class ComboBase : MonoBehaviour
{
    public string[] ValidKeys; // See keys above (these are defined in the editor)

    // RecentKeys represents keypresses that have just been made;
    // PressedKeys is the list of keys to be checked for a combo, as it has been processed to group combined presses together.
    private KeyCommand[] RecentKeys;
    private KeyCommand[] PressedKeys;
    private int currentkey = 0;

    private static int maxkeys = 10;


	void Start()
    {
        // Dimension array
        PressedKeys = new KeyCommand[maxkeys];
        RecentKeys = new KeyCommand[maxkeys];
        {
            // Initialize array elements to blank
            for (int key = 0; key < maxkeys; key++)
            {
                RecentKeys[key] = new KeyCommand();
                PressedKeys[key] = new KeyCommand();

                RecentKeys[key].keyPressed = "";
                RecentKeys[key].framePressed = 0;
                PressedKeys[key].keyPressed = "";
                PressedKeys[key].framePressed = 0;
            }
        }
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
                    // Store what was pressed, and when.
                    RecentKeys[currentkey].keyPressed = key;
                    RecentKeys[currentkey].framePressed = Time.renderedFrameCount;
                    RecentKeys[currentkey].combined = false;

                    // Increment starting position of the array, with looparound
                    currentkey++;
                    if (currentkey == maxkeys)
                    {
                        currentkey = 0;
                    }
                   
                }
            }
        }

        // Attempt to combine keypresses into combined keypresses.
        KeyCommand prevKeyCmd = RecentKeys[0];
        for (int key = 1; key < RecentKeys.Length; key++)
        {
            if(Math.Abs(RecentKeys[key].framePressed - prevKeyCmd.framePressed) <= 5 && prevKeyCmd.combined == false) // Within 5 frames
            {
                // Combine these keys.
                PressedKeys[key - 1].keyPressed = (RecentKeys[key].keyPressed) + prevKeyCmd.keyPressed;
                PressedKeys[key - 1].framePressed = RecentKeys[key].framePressed;
                RecentKeys[key].combined = true;
                PressedKeys[key - 1].combined = true;
            }
            else
            {
                PressedKeys[key - 1] = prevKeyCmd;
            }
            prevKeyCmd = RecentKeys[key];
        }

        //print(PressedKeys[0].keyPressed);
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
}
