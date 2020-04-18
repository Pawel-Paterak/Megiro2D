using OpenTK;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class Transform : Component
    {
        public Vector3 Position {
            get => position;
            set {
                SetChildsPosition(value);
                position = value;
            }
        }
        public Vector3 LocalPosition { get => GetLocalPosition(); }
        public Vector3 Rotation {
            get => rotation;
            set
            {
                rotation.X = SetRotation(value.X);
                rotation.Y = SetRotation(value.Y);
                rotation.Z = SetRotation(value.Z);
            }
        }
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        public int ChildCount { get => childs.Count; }
        public Transform Parent { get => parent; set => SetParent(value); }

        private Vector3 position = new Vector3();
        private Vector3 rotation = new Vector3();
        private List<Transform> childs = new List<Transform>();
        private Transform parent;

        public Transform()
        {
            Name = "Transform";
        }

        public void SetParent(Transform parent)
        {
            this.parent = parent;
            if (parent != null)
            {
                this.parent.AddChild(this);
            }
        }

        public Transform GetChild(int i)
            => childs[i];

        public Transform FindChild(string name)
        {
            foreach (Transform child in childs)
                if (child.gameObject.Name == name)
                    return child;
            return null;
        }

        public void SetChildsPosition(Vector3 position)
        {
            Vector3 offset = Position - position;

            foreach (var child in childs)
            {
                if (child != null)
                    child.Position -= offset;
                else
                    childs.Remove(child);
            }
        }

        private float SetRotation(float axis)
         => axis % 360;

        private void AddChild(Transform child)
         => childs.Add(child);

        private Vector3 GetLocalPosition()
        {
            if (parent == null)
                return Position;
            return parent.LocalPosition - Position;
        }
    }
}
