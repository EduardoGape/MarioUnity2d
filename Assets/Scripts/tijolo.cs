using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tijolo : MonoBehaviour
{
    private SpriteRenderer render;
    public float darkenAmount = 0.5f;
    public bool breacked = false;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void ResetBlockPosition(){
            float posx = transform.position.x;
            float posy = transform.position.y - 1;
            float posz = transform.position.z;
            transform.position = new Vector3(posx,posy,posz);
    }



    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && !breacked){
            breacked= true;
            float posx = transform.position.x;
            float posy = transform.position.y + 1;
            float posz = transform.position.z;
            transform.position = new Vector3(posx,posy,posz);
            render.color = DarkenColor(render.color, darkenAmount);
            Invoke("ResetBlockPosition", 0.4f);

        }
    }

    Color DarkenColor(Color originalColor, float darkenAmount){
        float r = Mathf.Lerp(originalColor.r, 0f, darkenAmount);
        float g = Mathf.Lerp(originalColor.g, 0f, darkenAmount);
        float b = Mathf.Lerp(originalColor.b, 0f, darkenAmount);
        return new Color(r, g, b, originalColor.a); 
    }



}
