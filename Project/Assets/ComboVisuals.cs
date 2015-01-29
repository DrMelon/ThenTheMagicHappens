using UnityEngine;
using System.Collections;

public class ComboVisuals : MonoBehaviour
{
    public Sprite[] ElementSprite; // Fire, Water, Earth, Lightning
    public int[] ElementButton; // Fire, Water, Earth, Lightning TODO: Don't, get element from combos
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

            // For each child of this script (which are the combo sprites)
            for (int child = 0; child < MaxSprites; child++)
            {
                // Reverse the ordering of the visuals
                int current = MaxSprites - child - 1;

                // Cast to KeyCommand & get the string of the key
                string key = ((KeyCommand)keys[current]).keyPressed;

                // If the key has been pressed, display this as a combo button visual
                if (key != "")
                {
                    print(int.Parse(key) - 1);
                    print(ElementButton[int.Parse(key) - 1]);
                    // Set the texture to the correct element
                    ComboSprite[child].GetComponent<SpriteRenderer>().sprite = ElementSprite[ElementButton[int.Parse(key)-1]];
                }
                else
                {
                    // Set the texture to blank
                    ComboSprite[child].GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
	}
}