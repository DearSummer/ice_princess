using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class NextTimelineAsset : PlayableAsset
{

    public ExposedReference<PlayableDirector> director;
    public PlayableAsset asset;

	// Factory method that generates a playable based on this asset
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
	{
	    var script = ScriptPlayable<NextTimelinePlayable>.Create(graph);
	    script.GetBehaviour().asset = asset;
	    script.GetBehaviour().director = director.Resolve(graph.GetResolver());
	    return script;
	}
}
