using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

	#region Fields

	private static T instance;

	#endregion

	#region Properties

	public static T Instance
	{
		get
		{
			return instance;
		}
	}

	#endregion

	#region Methods

	protected virtual void Awake()
	{
		if (instance != null)
		{
			Debug.LogErrorFormat("Error");
		}
		else
		{
			instance = (T)this;
		}
	}

	protected virtual void OnDestroy()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	#endregion

}