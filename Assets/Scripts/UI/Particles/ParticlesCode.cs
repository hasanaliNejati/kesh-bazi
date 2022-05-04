using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
public class ParticlesCode : MonoBehaviour
{

    public ParticleSystemRenderer[] particles;

    public bool UiParticle;


    public void setInfo(Color color, Vector3 pos)
    {
        transform.position = pos;

        
        

        if (UiParticle)
        {
            foreach(ParticleSystemRenderer p in particles)
            {
                changeMaterialColor( p.GetComponent<UIParticleSystem>().material);
            }
        }
        else
        {
            foreach (ParticleSystemRenderer p in particles)
            {
                foreach (Material m in p.materials)
                {
                    changeMaterialColor(m);
                    
                }
            }
        }

        void changeMaterialColor(Material material)
        {
            if (material.shader.name == "Legacy Shaders/Particles/Alpha Blended")
            {
                material.SetColor("_TintColor", color);
            }
            else
            {
                material.SetColor("_TintColor", color);
                print(material.shader.name);
            }
        }


    }

}
