using UnityEngine;
using System.Collections;

public class SpawnGameObjectsFixed : MonoBehaviour {
	
	public GameObject spawnPrefab;
	
	public int NumberOfObjects = 0;
	public float initialHeight = 1;

	public GameObject ParentObject;
	
	private float SpawnPositionX;
	private float SpawnPositionY;
	private float SpawnPositionZ;
	private Vector3 SpawnPosition;
	private GameObject Floor;
	private Collider FloorCollider;
	
	// Use this for initialization
	void Start () {
		
		Floor = GameObject.Find("Floor");
		FloorCollider = Floor.GetComponent<BoxCollider>();

		for (int i = 0; i < NumberOfObjects; i++) {
			SpawnPositionX = Random.Range (FloorCollider.bounds.min.x + 1, 
		                               FloorCollider.bounds.max.x - 1);

			SpawnPositionY = FloorCollider.bounds.max.y + initialHeight;

			SpawnPositionZ = Random.Range (FloorCollider.bounds.min.z + 1, 
		                               FloorCollider.bounds.max.z - 1);
			SpawnPosition = new Vector3 (SpawnPositionX, SpawnPositionY, SpawnPositionZ);

			MakeThingToSpawn ();
		}
		
	}

	
	void MakeThingToSpawn()
	{
		// create a new gameObject
		GameObject clone = Instantiate(spawnPrefab, SpawnPosition, transform.rotation) as GameObject;
		if (ParentObject != null){
			clone.transform.parent = ParentObject.transform;
		}

	}
}
