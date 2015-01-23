using UnityEngine;
using System.Collections;

public class ModifyTexture : MonoBehaviour {

    public Texture2D targetTexture;
   
    public int pixelsPerUnit = 100;

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
        }
    }

    public void DoSplat(Vector3 worldXYZ, int size, Color theColour)
    {
        // Calculate X, Y offsets
        //int posX = (int)((worldXYZ.x - this.transform.position.x) * (float)pixelsPerUnit);
        int posX = (int)(worldXYZ.x * pixelsPerUnit);
        int posY = (int)(worldXYZ.z * pixelsPerUnit);
       // int posY = (int)((worldXYZ.y - this.transform.position.y) * (float)pixelsPerUnit);
        

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
