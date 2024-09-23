using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TransitionRenderFeature : ScriptableRendererFeature
{
    //initialzing the render feature settings
    [System.Serializable]
    public class Settings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        //the transition shader, will automatically be assigned
        public Shader shader;
    }
    public Settings settings = new Settings();

    TransitionPass m_TransitionPass;

    //When render feature object is enabled, set the shader
    private void OnEnable()
    {
        settings.shader = Shader.Find("Hidden/Transition");
    }
    //sets the hatching's render pass up
    public override void Create()
    {
        this.name = "Transition Pass";
        if (settings.shader == null)
        {
            Debug.LogWarning("No Transition Shader");
            return;
        }
        m_TransitionPass = new TransitionPass(settings.renderPassEvent, settings.shader);
    }

    //call and adds the hatching render pass to the scriptable renderer's queue
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_TransitionPass);
    }
}