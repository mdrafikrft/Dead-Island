using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC : MonoBehaviour
{
    private static MUSIC instance;

	private void Awake()
	{
		if(instance == null){ 
			instance = this;
			DontDestroyOnLoad(instance);
		}else{ 
			Destroy(gameObject);
		}
	}
}
