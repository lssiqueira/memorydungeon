using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vela : MonoBehaviour {

    public int id;
    public int idPar;
    public bool acesa = false;
    private GerenciadorJogo memoria;
    [HideInInspector]
    public ParticleSystem ps;
    ParticleSystem.MainModule settings;

    // Use this for initialization
    void Start ()
    {
        memoria = GameObject.Find("GameManager").GetComponent<GerenciadorJogo>();
        ps = GetComponentInChildren<ParticleSystem>();
        settings = ps.main;
        AplicaCores();
        ps.Play();

        //transform.GetChild(0).gameObject.SetActive(false);
    }
	
    public void AplicaCores()
    {
        if (idPar == 0)
        {
            settings.startColor = Color.blue;
        }
        else if (idPar == 1)
        {
            settings.startColor = Color.yellow;
        }
        else
        {
            settings.startColor = Color.red;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        AcendeVela();
    }

    public void AcendeVela()
    {
        if (!acesa)
        {
            acesa = true;
            ps.Play();
            memoria.VerificaVelas(idPar, id);
            //transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
