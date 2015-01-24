using UnityEngine;
using System.Collections;

public class ModifyTexture : MonoBehaviour {

    public Texture2D targetTexture;
    public Texture2D scorchTexture;

    public Texture2D hello;


    public int pixelsPerUnit = 100;

    private int particleCollisions;

    private ParticleSystem.CollisionEvent[] collisionEvents = new ParticleSystem.CollisionEvent[16];

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

        if (particleCollisions > 100 || Time.renderedFrameCount % (60*5) == 0)
        {
            targetTexture.Apply();
            particleCollisions = 0;
        }
        

	}

    // Check for collisions
    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Collision!");
        DoSplat(collisionInfo.contacts[0].point, 32, Color.red);
    }

    void OnParticleCollision(GameObject particles)
    {
        ParticleSystem theParticles;
        theParticles = particles.GetComponent<ParticleSystem>();
        int safeLength = theParticles.safeCollisionEventSize;
        if (collisionEvents.Length < safeLength)
        {
            collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
        }

        int numCollisions = theParticles.GetCollisionEvents(gameObject, collisionEvents);
        int i = 0;
        while (i < numCollisions)
        {
            if (gameObject.rigidbody)
            {
                //Get collision location
                DoSplat(collisionEvents[i].intersection, 32, Color.red);
            }
            i++;
        }

        particleCollisions += numCollisions;

       
    }

    public void DoSplat(Vector3 worldXYZ, int size, Color theColour)
    {
        // Calculate X, Y offsets
        //int posX = (int)((worldXYZ.x - this.transform.position.x) * (float)pixelsPerUnit);
        int posX = (int)(worldXYZ.x * pixelsPerUnit);
        int posY = (int)(worldXYZ.z * pixelsPerUnit);
       // int posY = (int)((worldXYZ.y - this.transform.position.y) * (float)pixelsPerUnit);


        // Create a square ( will be a circle ) centred on x, y
      /*  for (int i = posX - size / 2; i < posX + size / 2; i++)
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
        }*/

        // Draw scorch.png texture at posX, posY
        Color[] scorchCols = scorchTexture.GetPixels();
        Color[] origCols = targetTexture.GetPixels(posX, posY, 64, 64);
        for(int c = 0; c < scorchCols.Length; c++)
        {

            // ALPHA BLENDING 
            float newR, newG, newB;

            newR = scorchCols[c].r * scorchCols[c].a;
            newG = scorchCols[c].g * scorchCols[c].a;
            newB = scorchCols[c].b * scorchCols[c].a;

            newR += origCols[c].r * (1 - scorchCols[c].a);
            newG += origCols[c].g * (1 - scorchCols[c].a);
            newB += origCols[c].b * (1 - scorchCols[c].a);
            
           
            
            

            scorchCols[c].r = newR;
            scorchCols[c].g = newG;
            scorchCols[c].b = newB;

        }

        targetTexture.SetPixels(posX, posY, 64, 64, scorchCols);

       

    }
}
