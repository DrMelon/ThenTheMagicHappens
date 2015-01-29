using UnityEngine;
using System.Collections;

public class ComboVisuals : MonoBehaviour
{
    public Sprite[] ElementSprite; // Fire, Water, Earth, Lightning
    public ComboBase Combo;

    private GameObject[] ComboSprite;
    private int MaxSprites = 10;

	void Start()
    {
        // Dimesion the array for storing the combo button sprites
        ComboSprite = new GameObject[MaxSprites];
        {
            // Display errors if not setup properly in editor
            if (transform.childCount < MaxSprites)
            {
                print("Warning: (ComboVisuals.cs) Not enough children to display all combo visuals");
            }

            // For each child of this script (which are the combo sprites)
            for (int child = 0; child < MaxSprites; child++)
            {
                // Store the children for combo visualising
                ComboSprite[child] = transform.GetChild(child).gameObject;
            }
        }
    }

	void Update()
    {
        // If Combo has been set in the editor
        if (Combo)
        {
            // Convert current frame combos to an array to iterate through
            object[] keys = Combo.RecentKeys.ToArray(); // KeyCommand type

            // Iterate through the keys and count the number of none null entries
            int currentkeys = 0;
            for (int child = 0; child < MaxSprites; child++)
            {
                // Cast to KeyCommand & get the string of the key
                string key = ((KeyCommand)keys[child]).keyPressed;
                if (key != "")
                {
                    currentkeys++; // Add to the none null key count
                }
                else
                {
                    // Set the texture to blank
                    ComboSprite[child].GetComponent<SpriteRenderer>().sprite = null;
                }
            }

            // For each child of this script (which are the combo sprites)
            for (int child = 0; child < MaxSprites; child++)
            {
                // Reverse the ordering of the visuals
                int current = child + (MaxSprites - currentkeys);
                if (current >= MaxSprites) { continue; }

                // Cast to KeyCommand & get the string of the key
                string key = ((KeyCommand)keys[current]).keyPressed;

                // If the key has been pressed, display this as a combo button visual
                if (key != "")
                {
                    // Get the element id of this key
                    int element = Combo.GetElement(key);

                    // Set the texture to the correct element
                    ComboSprite[child].GetComponent<SpriteRenderer>().sprite = ElementSprite[element];
                }
            }
        }
	}
}