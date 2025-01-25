using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block_ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];
    SpriteRenderer SpriteRenderer;

    [SerializeField]
    public Slider Modernity;

    [SerializeField]
    public Slider Folklore;

    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = sprites[0];
    }

    void Start()
    {
        Modernity.value = 0;
        Folklore.value = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (SpriteRenderer.sprite == sprites[0])
            {
                SpriteRenderer.sprite = sprites[1];
                FolkloreUp();
            }
            else if (SpriteRenderer.sprite == sprites[2])
            {
                SpriteRenderer.sprite = sprites[1];
                ModernityDown();
                FolkloreUp();
            }
        }
        else if (other.gameObject.tag == "Player2")
        {
            if (SpriteRenderer.sprite == sprites[0])
            {
                SpriteRenderer.sprite = sprites[2];
                ModernityUp();
            }
            else if (SpriteRenderer.sprite == sprites[1])
            {
                SpriteRenderer.sprite = sprites[2];
                ModernityUp();
                FolkloreDown();
            }
        }
    }

    void ModernityUp()
    {
        Modernity.value += 0.0065f;

        SoundManager.Instance.PlaySFXSound("GroundEat");

        GameManager.Instance.modernityScore++;

        ModernityValue();
    }

    void ModernityDown()
    {
        Modernity.value -= 0.0065f;

        GameManager.Instance.modernityScore--;

        ModernityValue();
    }

    void FolkloreUp()
    {
        Folklore.value += 0.0065f;

        SoundManager.Instance.PlaySFXSound("GroundEat");

        GameManager.Instance.folkloreScore++;

        FolkloreValue();
    }

    void FolkloreDown()
    {
        Folklore.value -= 0.0065f;

        GameManager.Instance.folkloreScore--;

        FolkloreValue();
    }

    void ModernityValue()
    {
        Modernity.value = Mathf.Lerp(Modernity.value, Modernity.value, Time.deltaTime * 10);
    }

    void FolkloreValue()
    {
        Folklore.value = Mathf.Lerp(Folklore.value, Folklore.value, Time.deltaTime * 10);
    }
}
