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
        public Vector3 Forward { get => GetForward(); }
        public Vector3 Top { get => GetTop(); }
        public Vector3 Left { get => GetLeft(); }
        public Vector3 LocalPosition { get => GetLocalPosition(); }

        public Vector3 EulerAngles
        {
            get => eulerAngles;
            set
            {
                eulerAngles.X = SetRotation(value.X);
                eulerAngles.Y = SetRotation(value.Y);
                eulerAngles.Z = SetRotation(value.Z);
                SetChildsRotation(eulerAngles);
            }
        }
        public Vector3 LocalEulerAngels { get => GetLocalEulerAngles(); }

        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        public int ChildCount { get => childs.Count; }
        public Transform Parent { get => parent; set => SetParent(value); }

        private Vector3 position = new Vector3();
        private Vector3 eulerAngles = new Vector3();
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

        public Transform GetChild(int index)
            => childs[index];

        public Transform FindChild(string name)
        {
            foreach (Transform child in childs)
                if (child.gameObject.Name == name)
                    return child;
            return null;
        }

        public void Translate(Vector3 offset)
        {
            Position += offset;
        }

        private void SetChildsPosition(Vector3 position)
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

        private void SetChildsRotation(Vector3 eulerAngles)
        {
            Vector3 offset = EulerAngles - eulerAngles;

            foreach (var child in childs)
            {
                if (child != null)
                    child.EulerAngles -= offset;
                else
                    childs.Remove(child);
            }
        }

        private Vector3 GetForward()
        {
            double division = (360 / MathHelper.TwoPi);
            float cosX = (float)Math.Cos(eulerAngles.X / division);
            float sinX = (float)Math.Sin(eulerAngles.X / division);

            float cosY = (float)Math.Cos(eulerAngles.Y / division);
            float sinY = (float)Math.Sin(eulerAngles.Y / division);

            return new Vector3(-sinY, sinX, -cosY * cosX);
        }

        private Vector3 GetTop()
        {
            double division = (360 / MathHelper.TwoPi);
            float cosX = (float)Math.Cos(eulerAngles.X / division);
            float sinX = (float)Math.Sin(eulerAngles.X / division);

            float cosZ = (float)Math.Cos(eulerAngles.Z / division);
            float sinZ = (float)Math.Sin(eulerAngles.Z / division);

            //return new Vector3(0, cosX, sinX);//sinZ , -cosZ * cosX, -sinX
            //return new Vector3(-sinZ, cosZ, 0);
            return new Vector3(-sinZ, cosZ * cosX, sinX);
        }

        private Vector3 GetLeft()
        {
            double division = (360 / MathHelper.TwoPi);
            float cosZ = (float)Math.Cos(eulerAngles.Z / division);
            float sinZ = (float)Math.Sin(eulerAngles.Z / division);

            float cosY = (float)Math.Cos(eulerAngles.Y / division);
            float sinY = (float)Math.Sin(eulerAngles.Y / division);

            return new Vector3(sinY, -sinZ, cosY * cosZ);
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

        private Vector3 GetLocalEulerAngles()
        {
            if (parent == null)
                return EulerAngles;
            return parent.LocalEulerAngels - EulerAngles;
        }
    }
}
