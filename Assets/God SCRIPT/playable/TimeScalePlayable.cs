using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TimeScalePlayable : PlayableBehaviour
{

    public AnimationCurve curve;

    private float maxTime;
    private float curTime = 0f;

	// Called when the owning graph starts playing
	public override void OnGraphStart(Playable playable) {
		
	}

	// Called when the owning graph stops playing
	public override void OnGraphStop(Playable playable)
	{
	    Time.timeScale = 1;
	}

	// Called when the state of the playable is set to Play
	public override void OnBehaviourPlay(Playable playable, FrameData info)
	{
	    maxTime = (float) playable.GetDuration();
	}

	// Called when the state of the playable is set to Paused
	public override void OnBehaviourPause(Playable playable, FrameData info) {
		
	}

	// Called each frame while the state is set to Play
	public override void PrepareFrame(Playable playable, FrameData info)
	{
	    curTime += Time.deltaTime;
	    Time.timeScale = curve.Evaluate(curTime / maxTime);
	}
}
