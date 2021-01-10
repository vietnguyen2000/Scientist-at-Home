using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixArt : MonoBehaviour
{
    Texture2D texture;
    Sprite sprite;
    public void RemoveColor(Color color)
    {
        if (color == Color.white) return;

        Color[] colors = this.sprite.texture.GetPixels();
        for (int i = 0; i<colors.Length; i++)
            if (color == colors[i])
                colors[i] = Color.white;

        this.texture.SetPixels(colors);
        this.texture.Apply();
    }

    public Color[] Remain()
    {
        Color[] colors = this.sprite.texture.GetPixels();
        Dictionary<Color, Color> dict = new Dictionary<Color, Color>();
        foreach (Color __color in colors)
            if (__color != Color.white && !dict.ContainsKey(__color))
                dict.Add(__color, __color);

        return new List<Color>(dict.Values).ToArray();
    }

    public bool AllWhite()
    {
        Color[] colors = this.sprite.texture.GetPixels();
        foreach (Color color in colors)
            if (color != Color.white) return false;

        return true;
    }

    public void Init()
    {
        this.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        Texture2D sprite_texture = this.sprite.texture;
        this.texture = new Texture2D(sprite_texture.width, sprite_texture.height, sprite_texture.format, false);
        this.texture.SetPixels(sprite_texture.GetPixels());
        this.texture.Apply();

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(this.texture, this.sprite.rect, new Vector2(0.5f, 0.5f), 16);
        this.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        this.texture = this.sprite.texture;
    }

    private void Awake()
    {
        this.Init();
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
