using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform segmentPrefab;

    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    [SerializeField] private AudioSource turningSoundEffect;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            turningSoundEffect.Play();
            _direction = Vector2.up;
        } 
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            turningSoundEffect.Play();
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            turningSoundEffect.Play();
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            turningSoundEffect.Play();
            _direction = Vector2.right;
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        } else if (Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i --) {
            _segments[i].position = _segments[i - 1].position;
        }
        
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }
        private void ResetState()
        {
            for (int i = 1; i < _segments.Count; i++) {
                Destroy(_segments[i].gameObject);
            }

            _segments.Clear();
            _segments.Add(this.transform);
            
            for (int i = 1; i < this.initialSize; i++) {
                _segments.Add(Instantiate(this.segmentPrefab));
            }

            this.transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    [SerializeField] private AudioSource deathSoundEffect;

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle") {
            deathSoundEffect.Play();
            ResetState();
            ScoreManager.instance.ResetScore();
        }
        
    }
    
     public ScoreManager scoreManager;
     
}