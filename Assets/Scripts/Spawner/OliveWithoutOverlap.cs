using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveWithoutOverlap : MonoBehaviour
{
    public int olivesToPlace = 32;
    public GameObject[] prefabs = new GameObject[0];
    GameObject olive;

    public float obstacleCheckRadius = 3f;
    public int maxSpawnAttemptsPerObstacle = 10;
    public GameObject spawner;

    void Awake()
    {

        for (int i = 0; i < olivesToPlace; i++)
        {
            olive = prefabs[Random.Range(0, prefabs.Length)];

            //Position value.
            Vector3 position = Vector3.zero;

            //whether or not we can spawn in this position
            bool validPosition = false;

            //How many times we've attempted to spawn this obstacle
            int spawnAttempts = 0;

            //While we don't have a valid position 
            //and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                //Increase our spawn attempts.
                spawnAttempts++;

                //Random position with our boundaries.
                position = new Vector3(Random.Range(-7.25f, 5.5f), 0.55f, Random.Range(-0.5f, 35.75f));
               
                validPosition = true;

                //All colliders within radius.
                Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

                //Loop for each collider.
                foreach (Collider col in colliders)
                {
                    // If collider tagged with "Olive" do not spawn.
                    if (col.tag == "Olive")
                    {
                        
                        validPosition = false;
                    }
                }
            }
            //If position is valid spawn olives.
            if (validPosition)
            {
                GameObject oliveClone = Instantiate(olive, position, Quaternion.identity);
                oliveClone.transform.parent = spawner.transform;
            }
        }
    }
}