using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour 
{
	public bool m_BattleTimeActive;
	public float m_BattleTime;
	public float m_PlayerTime;
	public float m_EnemyTime;
	public bool m_PlayerReady;
	public bool m_EnemyReady;
	public float m_PlayerCooldownTime = 5f;
	public float m_EnemyCooldownTime = 8f;

	public GameObject m_Player;
	public GameObject m_Enemy;
	public PlayerBattle m_PlayerScript;
	public EnemyBattle m_EnemyScript;

	public Canvas m_MenuCanvas;
	public GameObject m_EventSystem;

	private Button[] m_ButtonList;


	void Awake ()
	{
		m_PlayerScript = m_Player.GetComponent<PlayerBattle>();
		m_EnemyScript = m_Enemy.GetComponent<EnemyBattle>();
		m_ButtonList = m_MenuCanvas.GetComponentsInChildren<Button>();
	}

	// Use this for initialization
	void Start () 
	{
		m_BattleTimeActive = true;
		m_BattleTime = 0f;
		UnreadyPlayer();
		HideMenu();
		UnreadyEnemy();
	}


	// Update is called once per frame
	void Update () 
	{
		if (m_PlayerScript.m_isDead || m_EnemyScript.m_isDead)
		{
			EndBattle();
		}
		if (m_BattleTimeActive)
		{
			AddTime(Time.deltaTime);
			if (m_PlayerReady)
			{
				m_BattleTimeActive = false;
				ShowPlayerMenu();
			}
			if (m_EnemyReady)
			{
				EnemyAttack();
			}
		}
	}


	private void AddTime ( float pTime )
	{
		m_BattleTime += pTime;
		m_PlayerTime += pTime;
		m_EnemyTime += pTime;

		if (m_PlayerTime >= m_PlayerCooldownTime)
		{
			m_PlayerReady = true;
		}
		if (m_EnemyTime >= m_EnemyCooldownTime)
		{
			m_EnemyReady = true;
		}
	}


	private void ShowPlayerMenu ()
	{
		foreach ( Button button in m_ButtonList )
		{
			button.gameObject.SetActive(true);
		}
		print ("Menu");
	}


	private void EnemyAttack ()
	{
		UnreadyEnemy();
		print ("EnemyAttack");
		m_EnemyScript.ChooseAttack();
	}


	public void ActivateBattleTime ()
	{
		HideMenu();
		UnreadyPlayer();
		m_BattleTimeActive = true;
		print ("BattleTime reactivated");
	}


	public void UnreadyPlayer ()
	{
		m_PlayerTime = 0f;
		m_PlayerReady = false;
	}


	public void UnreadyEnemy ()
	{
		m_EnemyTime = 0f;
		m_EnemyReady = false;
	}


	public void HideMenu()
	{
		foreach ( Button button in m_ButtonList )
		{
			button.gameObject.SetActive(false);
		}
	}

	public void EndBattle()
	{
		m_BattleTimeActive = false;
		print ("The battle has finished");
	}
}


