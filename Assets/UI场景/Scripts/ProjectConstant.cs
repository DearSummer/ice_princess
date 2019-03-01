using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: 
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public static class ProjectConstant
    {
        public static GameState GAME_STATE = GameState.Normal;

        public static class Tag
        {
            public static readonly string GROUND = "Ground";
            public static readonly string PLAYER = "Player";
            public static readonly string ENEMY = "Enemy";
            public static readonly string ACTIVE_ENEMY = "ActiveEnemy";
            public static readonly string SKILL_CANVAS = "SkillCanvas";
        }

        public static class Layout
        {
            public static readonly string RENDER_OUTLINE = "RenderOutline";
            public static readonly string GROUND = "Ground";
       
        }

        public static class AnimatorParameter
        {
            public static readonly string BASE_LAYER_ANIMTION = "animation";

            public static readonly string FORWARD = "forward";
            public static readonly string JUMP = "jump";
            public static readonly string ON_GROUND = "onGround";
            public static readonly string AIR = "air";
            public static readonly string ROLL = "roll";
            public static readonly string ATTACK = "attack";
            public static readonly string DIE = "die";
            public static readonly string FIRE = "fire";
            public static readonly string ICE = "ice";
        }

        public class AnimatorLayer
        {
            public static readonly string BASE = "Base";
            public static readonly string ATTACK = "Attack";
        }

        public static class MessageBlock
        {
            public static readonly string FIGHT_MSG = "fight_msg";
            public static readonly string FIGHT_SYS = "fight_sys";
            public static readonly string CAMERA_SYS = "camera_sys";
            public static readonly string CAMERA_MSG = "camera_msg";
            public static readonly string UI_MSG = "0xffa";
            public static readonly string MENU_MSG = "0xmenu";
        }
        public static class Canvas
        {
            public static readonly string SkillCanvas = "SkillCanvas";
        }
  
    }
}
