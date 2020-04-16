namespace Megiro2D
{
    public class MegiroBehaviour : GameObject
    {
        public MegiroBehaviour()
        {
            Megiro.Singleton.AddBehaviour(this);
        }

        public virtual void Start()
        {

        }

        public virtual void Update(double time)
        {

        }
    }
}
