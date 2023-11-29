using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour {
    public float vida;
    public float tempVida;
    public GameObject barraDeVida;

    float contAtk = 0.0f;
    public float tempoDeAtaque;

    public float ataque;//quantos pontos de vida ele tira por ataque, 
                      //sendo que o player começa com 100 de vida

    public int porcVenenoso;//porcetagem de envenear o player
    public int porcParalizia;//porcetagem de paralisar o player

    private Player player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        tempVida = vida;
	}
	
	// Update is called once per frame
	void Update () {
		if(contAtk > tempoDeAtaque)
        {
            Ataque(player);
            contAtk = 0;
        }
        else
        {
            contAtk += Time.deltaTime;
        }

        if (vida <= tempVida)
        {
            barraDeVida.transform.localScale = new Vector2(tempVida, barraDeVida.transform.localScale.y);
            tempVida -= 0.01f;
        }
    }

    //cada ataque do player tira 10
    public void LevouDano()
    {
        vida -= 0.1f;
    }

    public void Ataque(Player player)
    {
        player.vida -= ataque;
    }
}
