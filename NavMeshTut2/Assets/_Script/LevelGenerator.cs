using UnityEngine;
using UnityEngine.AI;
public class LevelGenerator : MonoBehaviour {

	public int width;
	public int height;

	public GameObject wall;
	public GameObject player;
	private bool playerSpawned = false;
    private bool enemySpawned = false;
    public NavMeshSurface Navmesh;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
		GenerateLevel();
        Navmesh.BuildNavMesh();
	}
	
	// Create a grid based level
	void GenerateLevel()
	{
		// Loop over the grid
		for (int x = 0; x <= width; x+=2)
		{
			for (int y = 0; y <= height; y+=2)
			{
				// Should we place a wall?
				if (Random.value > .7f)
				{
					// Spawn a wall
					Vector3 pos = new Vector3(x - width / 2f, 0f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				} else if (!playerSpawned) // Should we spawn a player?
				{
					// Spawn the player
					Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}
                else if(!enemySpawned && x>width/2 && y>height/2) // Should we spawn a player?
                {
                    // Spawn the player
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(enemy, pos, Quaternion.identity);
                    enemySpawned = true;
                }
            }
		}
	}

}
