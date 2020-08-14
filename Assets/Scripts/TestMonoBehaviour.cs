using System;
using UnityEngine;

public class TestMonoBehaviour : MonoBehaviour
{
	private void Awake()
	{
		try
		{
			SlotManager.InitializeSlots();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
}