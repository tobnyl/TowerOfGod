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
	public bool interactable = false;


	void OnEnable(){
		AllBlocks.Add (this);
	}
	void OnDisable(){
		AllBlocks.Remove (this);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        var otherBlock = c.gameObject.GetComponent<Block>();
        var otherRigidBody = c.gameObject.GetComponent<Rigidbody2D>();
        var rigidBody = GetComponent<Rigidbody2D>();
       
        if (otherBlock != null) 
        {
			// do add more sounds!

            if (gameObject.tag == "Block" && otherBlock.tag == "Block" &&  c.relativeVelocity.magnitude > GameManager.Instance.DestroyBlockThreshold)
            {
                var offsetIncrement = transform.lossyScale/2f;
                var numExplosions = 3;
                var startPosition = transform.position - offsetIncrement;
                var offset = Vector3.zero;

                AudioManager.Instance.AddAudioClipToQueue(ExplosionClip);
                //AudioManager.Instance.Play(ExplosionClip, 0.2f, 0.2f, 1, 1);

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
        var vol = 0.05f;// Mathf.Max(0.05f, Mathf.Abs(c.relativeVelocity.normalized.y) / 15f);
        Debug.Log(vol);

        AudioManager.Instance.AddAudioClipToQueue(StackClip);

        //AudioManager.Instance.Play(StackClip, 0.01f, 0.05f, 1.0f, 1.0f);
    }
}
