using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	
	void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.name == "robot")
		{
			col.gameObject.GetComponent<RobotHealth>().SetHealth();
			Debug.Log("LA VIDA " + col.gameObject.GetComponent<RobotHealth>().GetHealth());
		}
		GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
		Destroy(e,1.5f);
		Destroy(this.gameObject);
		
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
