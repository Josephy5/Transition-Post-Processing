using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

//render pass code for the transition effect
public class TransitionPass : ScriptableRenderPass
{
    static readonly string renderPassTag = "Transition";

    private TransitionVolume TransitionVolume;
    //material containing the shader
    private Material TransitionMaterial;

    //initializes our variables
    public TransitionPass(RenderPassEvent evt, Shader Transitionshader)
    {
        renderPassEvent = evt;
        if (Transitionshader == null)
        {
            Debug.LogError("No Shader");
            return;
        }
        TransitionMaterial = CoreUtils.CreateEngineMaterial(Transitionshader);
    }
    //where our rendering of the effect starts
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (TransitionMaterial == null)
        {
            Debug.LogError("No Transition Material");
            return;
        }
        //in case if the camera doesn't have the post process option enabled or if the camera is the scene view camera
        //didn't use a debug log cuz it also effects preview camera for any 3d objects/animation and when scene or game is loading.
        //hence, doing so will cause premature logging errors that may not actually be an error
        if (!renderingData.cameraData.postProcessEnabled || renderingData.cameraData.cameraType == CameraType.SceneView)
        {
            //Debug.LogError("Post Processing in Camera not enabled");
            return;
        }

        //get the volume component of the transition effect
        VolumeStack stack = VolumeManager.instance.stack;
        TransitionVolume = stack.GetComponent<TransitionVolume>();

        //sets command buffer pool/CMD for rendering stuff
        var cmd = CommandBufferPool.Get(renderPassTag);
        Render(cmd, ref renderingData);

        //releases the CMD for cleanup
        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    //helper method to contain all of our rendering code for the Execute() method
    void Render(CommandBuffer cmd, ref RenderingData renderingData)
    {
        //we handle the setting the shader's material's parameters/variables in the transition volume script instead of here
        if (TransitionVolume.IsActive() == false) return;
        TransitionVolume.load(TransitionMaterial, ref renderingData);

        var source = renderingData.cameraData.renderer.cameraColorTarget;

        cmd.Blit(source, source, TransitionMaterial, 0);
    }
}