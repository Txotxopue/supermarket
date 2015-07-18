using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum AttackType
{
	Damage,
	Heal
}

[System.Serializable]
public struct Attack
{
	public string id;
	public AttackType type;
	public int amount;

	public Attack(string pId, AttackType pType, int pAmount)
	{
		id = pId;
		type = pType;
		amount = pAmount;
	}
}

[System.Serializable]
public class PlayerBattle : MonoBehaviour 
{
	public int mMaxHp;
	public int mCurrentHp;
	public Attack[] attackList;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Attack (string pId)
	{
		Attack attack = GetAttack (pId);
		if (attack.type == AttackType.Damage)
		{
			TakeDamage (attack.amount);
			print ("Attack " + pId + " deals " + attack.amount + " damage.");
		}
		if (attack.type == AttackType.Heal)
		{
			HealDamage(attack.amount);
			print ("Attack " + pId + " heals " + attack.amount + " damage.");
		}
	}
	

	public Attack GetAttack (string pId)
	{
		foreach (Attack attack in attackList)
		{
			if (attack.id == pId)
			{
				return attack;
			}
		}
		return new Attack(pId, AttackType.Damage, 0);
	}


	public void TakeDamage (int pAmount)
	{
		mCurrentHp -= pAmount;
		if (mCurrentHp <= 0)
		{
			mCurrentHp = 0;
		}
	}


	public void HealDamage (int pAmount)
	{
		mCurrentHp += pAmount;
		if (mCurrentHp > mMaxHp)
		{
			mCurrentHp = mMaxHp;
		}
	}

}
