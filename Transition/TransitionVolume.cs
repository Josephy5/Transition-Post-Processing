using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable, VolumeComponentMenu("Transition")]
public class TransitionVolume : VolumeComponent, IPostProcessComponent
{
    //the customizable parameters for the shader
    public Texture2DParameter _TransitionTexture = new Texture2DParameter(null, true);
    public BoolParameter _UseScreenTexure = new BoolParameter(false, true);
    public Texture2DParameter _ScreenTexure = new Texture2DParameter(null, true);
    public ColorParameter _Color = new ColorParameter(Color.black, true);
    public FloatParameter _Cutoff = new ClampedFloatParameter(0f, 0f, 1f, true);
    public FloatParameter _Fade = new ClampedFloatParameter(1f, 0f, 1f, true);

    //set the parameters for the render pass's material
    public void load(Material material, ref RenderingData renderingData)
    {
        material.SetTexture("_TransitionTex", _TransitionTexture.value);
        material.SetInt("_UseTransitionScreenTex", _UseScreenTexure.value ? 1 : 0);
        material.SetTexture("_TransitionScreenTex", _ScreenTexure.value);
        material.SetColor("_Color", _Color.value);
        material.SetFloat("_Cutoff", _Cutoff.value);
        material.SetFloat("_Fade", _Fade.value);
    }

    public bool IsActive() => true;
    public bool IsTileCompatible() => false;
}