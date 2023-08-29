using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class showNPC : MonoBehaviour
{
    public GameObject F_sleep;
    public GameObject F_stand;
    public GameObject Nin_stand;
    public GameObject Poom_basic;
    public GameObject Poom_normal_face;

    // public GameObject timeBoxPrefab; 

    void Start()
    {
        Lua.RegisterFunction("SwitchNPCF_Stand_to_F_sleep", this, typeof(showNPC).GetMethod("SwitchNPCF_Stand_to_F_sleep"));
        Lua.RegisterFunction("SwitchNPCF_Stand_to_Nin_stand", this, typeof(showNPC).GetMethod("SwitchNPCF_Stand_to_Nin_stand"));
        Lua.RegisterFunction("SwitchNPCNin_Stand_to_F_stand", this, typeof(showNPC).GetMethod("SwitchNPCNin_Stand_to_F_stand"));
        Lua.RegisterFunction("SwitchNPCF_Sleep_to_F_stand", this, typeof(showNPC).GetMethod("SwitchNPCF_Sleep_to_F_stand"));
        Lua.RegisterFunction("SwitchNPCF_Sleep_to_Nin_stand", this, typeof(showNPC).GetMethod("SwitchNPCF_Sleep_to_Nin_stand"));
        Lua.RegisterFunction("SetPoomNPC", this, typeof(showNPC).GetMethod("SetPoomNPC"));
    }

    public void SwitchNPCF_Stand_to_F_sleep()
    {
        if (F_stand)
        {
            F_stand.SetActive(false);
        }
        if (Nin_stand)
        {
            Nin_stand.SetActive(false);
        }
        if (F_sleep)
        {
            F_sleep.SetActive(true);
        }

    }
    public void SwitchNPCF_Stand_to_Nin_stand()
    {
        if (F_stand)
        {
            F_stand.SetActive(false);
        }
        if (Nin_stand)
        {
            Nin_stand.SetActive(true);
        }
        if (F_sleep)
        {
            F_sleep.SetActive(false);
        }

    }

    public void SwitchNPCNin_Stand_to_F_stand()
    {
        if (F_stand)
        {
            F_stand.SetActive(true);
        }
        if (Nin_stand)
        {
            Nin_stand.SetActive(false);
        }
        if (F_sleep)
        {
            F_sleep.SetActive(false);
        }

    }

    public void SwitchNPCF_Sleep_to_F_stand()
    {
        if (F_stand)
        {
            F_stand.SetActive(true);
        }
        if (Nin_stand)
        {
            Nin_stand.SetActive(false);
        }
        if (F_sleep)
        {
            F_sleep.SetActive(false);
        }
    }

    public void SwitchNPCF_Sleep_to_Nin_stand()
    {
        if (F_stand)
        {
            F_stand.SetActive(false);
        }
        if (Nin_stand)
        {
            Nin_stand.SetActive(true);
        }
        if (F_sleep)
        {
            F_sleep.SetActive(false);
        }
    }
    public void SetNPCOff()
    {
        F_stand.SetActive(false);
        Nin_stand.SetActive(false);
        F_sleep.SetActive(false);
        Poom_basic.SetActive(false);
        Poom_normal_face.SetActive(false);

    }

    public void SetPoomNPC()
    {
        SetNPCOff();
        Poom_normal_face.SetActive(true);
        Poom_basic.SetActive(true) ;
    }


}