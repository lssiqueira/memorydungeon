using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [HideInInspector]
    public GameObject[] velas = new GameObject[6];

    public float vida;
    public float tempVida;
    public GameObject barraDeVida;
    public Image barraStatus;

    public float contTempo = 0.0f;

    [HideInInspector]
    public int tempoEvenenado;
    [HideInInspector]
    public int tempoParalisado;

    public enum Status {normal, envenenado, paralisado};
    public Status status = Status.normal;

	// Use this for initialization
	void Start () {
        tempVida = vida;

        for (int i = 0; i < 6; i++)
        {
            velas[i] = GameObject.Find("Vela" + (i + 1));
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (status)
        {
            case Status.envenenado:
                if (contTempo > tempoEvenenado)
                {
                    contTempo = 0;
                    status = Status.normal;
                    barraStatus.color = Color.black;
                }
                else
                {
                    vida -= 0.0001f;
                    contTempo += Time.deltaTime;
                    barraStatus.color = new Color(0,0.5f,0);
                }

                break;
            case Status.paralisado:
                if(contTempo > tempoParalisado)
                {
                    contTempo = 0;
                    status = Status.normal;
                    for (int i = 0; i < 6; i++)
                    {
                        velas[i].GetComponent<Collider>().enabled = true;
                    }

                    barraStatus.color = Color.black;
                }
                else
                {
                    for(int i = 0; i < 6; i++)
                    {
                        velas[i].GetComponent<Collider>().enabled = false;
                    }

                    contTempo += Time.deltaTime;
                    barraStatus.color = Color.cyan;
                }
                break;
        }
        if (vida <= tempVida)
        {
            barraDeVida.transform.localScale = new Vector2(tempVida, barraDeVida.transform.localScale.y);
            tempVida -= 0.01f;
        }
	}
}
