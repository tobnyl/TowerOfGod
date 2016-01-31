using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour {

	// public statics
	public static List<Block> AllBlocks = new List<Block>();
	public bool inPlay;
	public float SpawnAngle = 0;
    public GameObject ExplosionPrefab;
    public AudioClip ExplosionClip;
    public AudioClip StackClip;

	// publics
	public bool Interactive = false;
	public bool IsNew = true;

	// secret publics
	[HideInInspector]
	public Vector3 OriginalScale;


	void OnEnable(){
		AllBlocks.Add (this);
	}
	void OnDisable(){
		AllBlocks.Remove (this);
	}
	void Awake(){
		OriginalScale = transform.localScale;
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        var otherBlock = c.gameObject.GetComponent<Block>();
       
        if (otherBlock != null) 
        {
			// do add more sounds!

            if (gameObject.tag == "Block" && otherBlock.tag == "Block" && (otherBlock.GetComponent<Rigidbody2D>().mass <= GetComponent<Rigidbody2D>().mass) &&  (GetComponent<Rigidbody2D>().velocity.magnitude * GetComponent<Rigidbody2D>().mass) > GameManager.Instance.DestroyBlockThreshold)
            {
                var offsetIncrement = transform.lossyScale/2f;
                var numExplosions = 3;
                var startPosition = transform.position - offsetIncrement;
                var offset = Vector3.zero;

                //AudioManager.Instance.AddAudioClipToQueue(ExplosionClip);
                AudioManager.Instance.Play(ExplosionClip, 0.01f, 0.06f, 0.99f, 1.01f);

                for (int i = 0; i < numExplosions; i++)
                {                    
                    var explosion = Instantiate(ExplosionPrefab, startPosition + offset, Quaternion.identity);
                    Destroy(explosion, 1.0f);

                    offset += offsetIncrement;
                }

                Destroy(c.gameObject);
            }
            else
            {
                PlayStackSoundEffect(c);
            }     
        }
        else
        {
            PlayStackSoundEffect(c);
        }
    }

    private void PlayStackSoundEffect(Collision2D c)
    {
        var vol = Mathf.Max(0.3f, Mathf.Abs(c.relativeVelocity.normalized.y) / 4f);
        Debug.Log(vol);

        //AudioManager.Instance.AddAudioClipToQueue(StackClip);

        AudioManager.Instance.Play(StackClip, vol, vol, 1.0f, 1.0f);
    }
}
