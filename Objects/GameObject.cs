﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Audio;

namespace PourMeSomePuree
{
    class GameObject : I_Updatable, I_Drawable
    {
        protected Texture texture;
        protected Sprite sprite;

        protected AudioSource audioSource;
        protected AudioClip audioClip;

        public RigidBody RigidBody;
        public bool IsActive;

        public Sprite Sprite { get { return sprite; } }
        public virtual Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public Vector2 Pivot { get { return sprite.pivot; } set { sprite.pivot = value; } }
        public float HalfWidth { get { return sprite.Width * 0.5f; } }
        public float HalfHeight { get { return sprite.Height * 0.5f; } }

        public GameObject(string textureName = null, float spriteWidth = 0, float spriteHeight = 0)
        {
            float spriteW = 0.0f;
            float spriteH = 0.0f;

            if (textureName != null)
            {
                texture = GfxMgr.GetTexture(textureName);

                spriteW = spriteWidth != 0 ? spriteWidth : texture.Width;
                spriteH = spriteHeight != 0 ? spriteHeight : texture.Height;
            }

            sprite = new Sprite(spriteW, spriteH);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            UpdateMgr.AddItem(this);
            DrawMgr.AddItem(this);
        }

        public virtual void Update() { }

        public virtual void Draw()
        {
            if (texture != null)
            {
                sprite.DrawTexture(texture); 
            }
        }

        public virtual void Draw(Texture texture)
        {
            sprite.DrawTexture(texture);
        }

        public virtual void OnCollide(GameObject other) { }

        public virtual void Destroy()
        {
            texture = null;
            sprite = null;
            audioSource = null;
            audioClip = null;
            RigidBody = null;
        }

        public virtual void OnDie() { }
    }
}
