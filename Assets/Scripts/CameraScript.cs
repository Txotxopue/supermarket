using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{

	public GameObject m_PlayerCamera;
	private Camera m_PlayerCameraComponent;
	private Camera m_CameraComponent;


	// Use this for initialization
	void Start () 
	{
		m_CameraComponent = gameObject.GetComponent<Camera>();
		m_PlayerCameraComponent = m_PlayerCamera.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTravelFinished ()
	{
		m_CameraComponent.tag = "Untagged";
		m_CameraComponent.enabled = false;
		m_PlayerCameraComponent.enabled = true;
		m_PlayerCameraComponent.tag = "MainCamera";
	}
}
