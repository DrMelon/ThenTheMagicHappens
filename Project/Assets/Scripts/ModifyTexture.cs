using UnityEngine;
using System.Collections;

public class ModifyTexture : MonoBehaviour {

    public Texture2D blackTexture;
    public Texture2D whiteTexture;

    public int pixelsPerUnit = 100;

	// Use this for initialization
	void Start () 
    {
        // HACKY STUFF!!
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                blackTexture.SetPixel(i, j, Color.black);
            }
        }

        // Write
        blackTexture.Apply();

        // HACKY STUFF!!
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                whiteTexture.SetPixel(i, j, Color.white);
            }
        }

        // Write
        whiteTexture.Apply();

	}
	
	// Update is called once per frame
	void Update () 
    {
	   


	}

    // Check for collisions
    void OnCollisionEnter(Collision collisionInfo)
    {
        DoSplat(collisionInfo.contacts[0].point, 32, Color.red);
    }

    public void DoSplat(Vector3 worldXYZ, int size, Color theColour)
    {
        // Calculate X, Y offsets
        int posX = (int)worldXYZ.x - (int)this.transform.position.x;
        posX /= pixelsPerUnit;

        int posY = (int)worldXYZ.y - (int)this.transform.position.y;
        posY /= pixelsPerUnit;

    }
}
