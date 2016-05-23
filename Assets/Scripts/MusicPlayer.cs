using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	// need to go before start -- check order of execution
	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
			print ("Duplicate music player self destructed.");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	
	}
	
	
}
