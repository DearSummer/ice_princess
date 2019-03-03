using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TimeScaleAsset : PlayableAsset
{

    public AnimationCurve curve;
	// Factory method that generates a playable based on this asset
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
	{
	    var script = ScriptPlayable<TimeScalePlayable>.Create(graph);
	    script.GetBehaviour().curve = curve;
	    return script;
	}
}
