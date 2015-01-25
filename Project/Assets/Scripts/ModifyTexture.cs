using UnityEngine;
using System.Collections;
using System.IO;

public class ModifyTexture : MonoBehaviour {

    public Texture2D targetTexture;
	public Color defaultColor;
    //public Texture2D scorchTexture;

    public bool needSave;


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
				targetTexture.SetPixel(i, j, defaultColor);

            }
        }

        // Write
        targetTexture.Apply();
        needSave = false;


	}
	
	// Update is called once per frame
	void Update () 
    {

        if (particleCollisions > 100 || Time.renderedFrameCount % (60*5) == 0)
        {
            targetTexture.Apply();
            particleCollisions = 0;
        }

        // Debug: force a capture
        if (needSave)
        {
            SaveToFile("test.png");
            needSave = false;
        }

	}


    // Do particle collisions
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
                DoSplat(collisionEvents[i].intersection, 32, Color.red, particles);
            }
            i++;
        }

        particleCollisions += numCollisions;

       
    }

    public void SaveToFile(string filename)
    {
        


        // Write as PNG
        byte[] outBytes = targetTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/" + filename, outBytes);
    }

    public void DoSplat(Vector3 worldXYZ, int size, Color theColour, GameObject particles)
    {

        Texture2D scorchTexture = null;

        // Fetch scorchtexture from particle system
        if(particles != null)
        {
            if(particles.GetComponent<ScorchInfo>() != null)
            {
                scorchTexture = particles.GetComponent<ScorchInfo>().scorchTexture;
            }
        }
       


        if (scorchTexture != null)
        {
            // Calculate X, Y offsets
            float partPosX = (worldXYZ.x - (this.transform.position.x - this.transform.localScale.x / 2));
            float partPosY = (worldXYZ.y - (this.transform.position.y - this.transform.localScale.y / 2));
            int posX = (int)(partPosX * pixelsPerUnit * 2);
            int posY = (int)(partPosY * pixelsPerUnit * 2);
            if(posX < 0)
			{
				posX -= posX*2;
				return;
			}
			if(posY < 0)
			{
				posY -= posY*2;
			}

            // Clamp pixel sampling/writing location values
            int numPixX = 64;
            int numPixY = 64;
            if (2048 - posX < 64)
            {
                numPixX = 2048 - posX;
            }
            if (2048 - posY < 64)
            {
                numPixY = 2048 - posY;
            }
            if(numPixX <= 0 || numPixY <= 0)
            {
                return;
            }

            // Draw scorch.png texture at posX, posY
            Color[] scorchCols = scorchTexture.GetPixels();
            Color[] origCols = targetTexture.GetPixels(posX, posY, numPixX, numPixY);
            for (int c = 0; c < origCols.Length; c++)
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
                // Fix alpha
                scorchCols[c].a = 1.0f;

            }


            targetTexture.SetPixels(posX, posY, numPixX, numPixY, scorchCols);

        }

    }
}
