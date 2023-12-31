using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
         
    }

    [SerializeField] private AudioSource foodSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.instance.AddPoint();

        if (other.tag == "Player") 
        {
            foodSoundEffect.Play();
            RandomizePosition();
        }
        
    }
}
