using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixArt : MonoBehaviour
{
    Texture2D texture;
    Sprite sprite;
    AudioSource audioSource;
    private Vector3 _originalPos;
    public void RemoveColor(Color color)
    {
        if (color == Color.white) return;

        Color[] colors = this.sprite.texture.GetPixels();
        for (int i = 0; i<colors.Length; i++)
            if (color == colors[i])
                colors[i] = Color.white;

        this.texture.SetPixels(colors);
        this.texture.Apply();
        StartCoroutine(cShake(0.3f,0.3f));
        audioSource.Play();
    }

    public Color[] Remain()
    {
        Color[] colors = this.sprite.texture.GetPixels();
        Dictionary<Color, Color> dict = new Dictionary<Color, Color>();
        foreach (Color __color in colors)
            if(__color.a != 0){
                if (__color != Color.white && !dict.ContainsKey(__color))
                dict.Add(__color, __color);
            }
            

        return new List<Color>(dict.Values).ToArray();
    }

    public bool AllWhite()
    {
        Color[] colors = this.sprite.texture.GetPixels();
        foreach (Color color in colors)
            if(color.a != 0){
                if (color != Color.white) return false;
            }
        return true;
    }

    public void Init()
    {
        this.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        Texture2D sprite_texture = this.sprite.texture;
        this.texture = new Texture2D(sprite_texture.width, sprite_texture.height, sprite_texture.format, false);
        this.texture.filterMode = FilterMode.Point;
        this.texture.SetPixels(sprite_texture.GetPixels());
        this.texture.Apply();

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(this.texture, this.sprite.rect, new Vector2(0.5f, 0.5f), 16);
        this.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        this.texture = this.sprite.texture;
    }

    private void Awake()
    {
        this.Init();
        _originalPos = transform.localPosition;
        audioSource = GetComponent<AudioSource>();
    }
    public IEnumerator cShake (float duration, float amount) {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (startTime < endTime && Time.timeScale > 0f) {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            startTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
    /*    
    int count = 0;
    private void Update()
    {
        Debug.Log(AllWhite());
        Color[] colors = this.Remain();
        if (colors.Length > 0)
        {
            Debug.Log("Remove color " + colors.Length + " " + colors[0]);
            this.RemoveColor(colors[0]);
        }
        else Debug.Log("No color remain");
    }

    //DEBUG ONLY */
}
