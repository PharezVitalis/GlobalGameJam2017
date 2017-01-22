using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {


    [SerializeField]
    private Sprite[] sprite = new Sprite[3];

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        int rnd = Random.Range(0, 3);
        sr.sprite = sprite[rnd];
    }
}
