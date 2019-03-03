using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class CharacterStateLockAsset : PlayableAsset
{

    public ExposedReference<Animator> anim;

	// Factory method that generates a playable based on this asset
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
	{
	    var script = ScriptPlayable<CharacterLockStatePlayable>.Create(graph);
	    script.GetBehaviour().anim = anim.Resolve(graph.GetResolver());
	    return script;
	}
}
