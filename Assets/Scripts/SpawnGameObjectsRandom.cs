using UnityEngine;
using System.Collections;

public class SpawnGameObjectsRandom : MonoBehaviour {
	
	public GameObject spawnPrefab;
	
	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
//	public float Xmax = 0.0f;
//	public float Xmin = 0.0f;
//	
//	public float Ymax = 0.0f;
//	public float Ymin = 0.0f;
//	
//	public float Zmax = 0.0f;
//	public float Zmin = 0.0f;
	
	public Transform chaseTarget;
	public float initialHeight;

	public GameObject ParentObject;
	
	private float savedTime;
	private float secondsBetweenSpawning;
	private float SpawnPositionX;
	private float SpawnPositionY;
	private float SpawnPositionZ;
	private Vector3 SpawnPosition;
	private GameObject Floor;
	private Collider FloorCollider;
	
	// Use this for initialization
	void Start () {
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

		Floor = GameObject.Find("Floor");
		FloorCollider = Floor.GetComponent<BoxCollider>();

		SpawnPositionX = Random.Range (FloorCollider.bounds.min.x + 1, 
		                               FloorCollider.bounds.max.x - 1);
		if (initialHeight > 1) {
			SpawnPositionY = initialHeight;
		} else {
			SpawnPositionY = 1; // Constant to spawn above floor
		}
		SpawnPositionZ = Random.Range (FloorCollider.bounds.min.z, 
		                               FloorCollider.bounds.max.z);
		SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
		{
			MakeThingToSpawn();
			savedTime = Time.time; // store for next spawn
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

			FloorCollider = Floor.GetComponent<BoxCollider>();

			SpawnPositionX = Random.Range (FloorCollider.bounds.min.x + 1, 
			                               FloorCollider.bounds.max.x - 1);
			if (initialHeight > 1) {
				SpawnPositionY = initialHeight;
			} else {
				SpawnPositionY = 1; // Constant to spawn above floor
			}
			SpawnPositionZ = Random.Range (FloorCollider.bounds.min.z + 1, 
			                               FloorCollider.bounds.max.z - 1);
			SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);

		}	
	}
	
	void MakeThingToSpawn()
	{
		// create a new gameObject
		GameObject clone = Instantiate(spawnPrefab, SpawnPosition, transform.rotation) as GameObject;
		if (ParentObject != null){
			clone.transform.parent = ParentObject.transform;
		}
		
		// set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}
}
