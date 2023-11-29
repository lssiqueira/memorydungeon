using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;

public class GerenciadorJogo : MonoBehaviour {

    public Vela[] velas;
    public int click1 = -1, idClicado = -1, velasAcertadas = 0;
    public List<int> ids;
    public Monstro monstro;

    public ParticleSystem efeitoDanoMonstro;


    // Use this for initialization
    void Awake () {
        ids = Shuffle(ids);
        for (int i = 0; i < ids.Count; i++)
        {
            velas[i].idPar = ids[i];
            StartCoroutine(StopEffectSpecificId(velas[i].id));
        }
        monstro = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monstro>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void VerificaVelas(int idPar, int id)
    {
        if(click1 == -1)
        {
            click1 = idPar;
            idClicado = id;
        }
        else
        {
            if(click1 != idPar)
            {
                velas[id].acesa = false;
                velas[idClicado].acesa = false;

                StartCoroutine(StopEffect(id));
            }
            else
            {
                velasAcertadas++;
                click1 = -1;
                idClicado = -1;
            }

        }

        if(velasAcertadas == 3)
        {
            monstro.LevouDano();
            efeitoDanoMonstro.Play();
            StartCoroutine(StopEffectDanoMonstro());

            for (int i = 0; i < velas.Length; i++)
            {
                velas[i].acesa = false;
                StartCoroutine(StopEffectSpecificId(i));
            }

            ids = Shuffle(ids);
            for (int i = 0; i < ids.Count; i++)
            {
                velas[i].idPar = ids[i];
                velas[i].AplicaCores();
            }

            velasAcertadas = 0;
        }
    }

    public IEnumerator StopEffectDanoMonstro()
    {
        yield return new WaitForSeconds(1f);

        efeitoDanoMonstro.Stop();
    }

    public IEnumerator StopEffect(int id)
    {
        yield return new WaitForSeconds(1f);

        velas[id].ps.Stop();
        velas[idClicado].ps.Stop();
        click1 = -1;
        idClicado = -1;
    }

    public IEnumerator StopEffectSpecificId(int id)
    {
        yield return new WaitForSeconds(1f);

        velas[id].ps.Stop();
    }

    public List<int> Shuffle(List<int> list)
    {
        var rng = new System.Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }

}
