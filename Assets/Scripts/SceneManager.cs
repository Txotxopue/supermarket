using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Application.LoadLevel(2);
		}
	}
}
