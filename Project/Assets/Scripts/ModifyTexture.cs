using UnityEngine;
using System.Collections;

public class ModifyTexture : MonoBehaviour {

    public Texture2D targetTexture;
   
    public int pixelsPerUnit = 100;

	// Use this for initialization
	void Start () 
    {
        // HACKY STUFF!!
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                targetTexture.SetPixel(i, j, Color.black);
            }
        }

        // Write
        targetTexture.Apply();



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

        print(worldXYZ);
        print(posX);
        print(posY);


        // Create a square ( will be a circle ) centred on x, y
        for (int i = posX - size / 2; i < posX + size / 2; i++)
        {
            for(int j = posY - size / 2; j < posY + size / 2; j++)
            {
                if(i > 0 && i < 2048)
                {
                    if(j > 0 && j < 2048)
                    {
                        targetTexture.SetPixel(i, j, theColour);
                    }
                }
            }
        }

        targetTexture.Apply();

    }
}
