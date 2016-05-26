using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;				
		}		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	

	
	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint( crack, transform.position, 0.1f );
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		int maxHits = hitSprites.Length + 1;
		timesHit++;				
		if (timesHit >= maxHits) {
			breakableCount--;
			puffSmoke();
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}
	
	void puffSmoke() {
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;//instantiate just returns Object not GameObject
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	

	
}
