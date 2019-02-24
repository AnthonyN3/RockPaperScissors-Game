using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternating_Animation : MonoBehaviour
{
    public GameObject RockL;
    public GameObject RockR;
    public GameObject PaperL;
    public GameObject PaperR;
    public GameObject ScissorL;
    public GameObject ScissorR;
    public bool loop = true;
    void Start()
    {
       // AlternateL();
        StartCoroutine(AlternateL());
        StartCoroutine(AlternateR());
       // AlternateR();
    }

   /* public void AlternateL()
    {
        if(!loop)
            return;
        Invoke("ActivateRockL", 0.2f);
        if(!loop)
            return;
        Invoke("ActivatePaperL", 0.4f);
        if(!loop)
            return;
        Invoke("ActivateScissorL", 0.6f);
        if(!loop)
            return;
        Invoke("AlternateL", 0.6f);
    }*/

    public IEnumerator AlternateL()
    {
        yield return new WaitForSeconds(0.2f);
         if(!loop)
            yield break;
        ActivateRockL();

        yield return new WaitForSeconds(0.2f);
        if(!loop)
            yield break;
        ActivatePaperL();

        yield return new WaitForSeconds(0.2f);
        if(!loop)
            yield break;
        ActivateScissorL();

        if(!loop)
            yield break;
        StartCoroutine(AlternateL());
    }

    public IEnumerator AlternateR()
    {
        yield return new WaitForSeconds(0.2f);
         if(!loop)
            yield break;
        ActivateScissorR();

        yield return new WaitForSeconds(0.2f);
        if(!loop)
            yield break;
        ActivateRockR();

        yield return new WaitForSeconds(0.2f);
        if(!loop)
            yield break;
        ActivatePaperR();

        if(!loop)
            yield break;
        StartCoroutine(AlternateR());
    }

  /*   public void AlternateR()
    {
        if(!loop)
            return;
        Invoke("ActivateScissorR", 0.2f);
        if(!loop)
            return;
        Invoke("ActivateRockR", 0.4f);
        if(!loop)
            return;
        Invoke("ActivatePaperR", 0.6f);
        if(!loop)
            return;
        Invoke("AlternateR", 0.6f);
    
    }*/

    public void ActivateRockL()
    {
        RockL.SetActive(true);
        PaperL.SetActive(false);
        ScissorL.SetActive(false);
    }
    public void ActivatePaperL()
    {
        PaperL.SetActive(true);
        RockL.SetActive(false);
        ScissorL.SetActive(false);
    }
    public void ActivateScissorL()
    {
        ScissorL.SetActive(true);
        PaperL.SetActive(false);
        RockL.SetActive(false);
    }

     public void ActivateRockR()
    {
        RockR.SetActive(true);
        PaperR.SetActive(false);
        ScissorR.SetActive(false);
    }
    public void ActivatePaperR()
    {
        PaperR.SetActive(true);
        RockR.SetActive(false);
        ScissorR.SetActive(false);
    }
    public void ActivateScissorR()
    {
        ScissorR.SetActive(true);
        PaperR.SetActive(false);
        RockR.SetActive(false);
    }
}
