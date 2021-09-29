
using UnityEngine;
using Cinemachine;


[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] 
public class CineMachineAxisLock : CinemachineExtension
{
    // Cine machine Extension to keep camera on fixed height
    public float CameraHeight = 10;

    //inner system callback
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            // change height with editor value
            pos.y = CameraHeight;
            state.RawPosition = pos;
        }
    }
}

