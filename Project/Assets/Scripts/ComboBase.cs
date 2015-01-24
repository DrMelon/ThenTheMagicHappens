using UnityEngine;
using System.Collections;

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

    private string[] RecentKeys;
    private int currentkey = 0;

    private static int maxkeys = 10;

	void Start()
    {
        // Dimension array
        RecentKeys = new string[maxkeys];
        {
            // Initialize array elements to blank
            for (int key = 0; key < maxkeys; key++)
            {
                RecentKeys[key] = "";
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
                    RecentKeys[currentkey] = key;

                    // Increment starting position of the array, with looparound
                    currentkey++;
                    if (currentkey == maxkeys)
                    {
                        currentkey = 0;
                    }
                }
            }
        }
        print(RecentKeys[maxkeys - 1]);
	}
}