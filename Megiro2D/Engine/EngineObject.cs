namespace Megiro2D.Engine
{
    public class EngineObject
    {
        public string Name { get; set; } = "";

        public static void Destroy(EngineObject obj)
        {
            Megiro.Singleton.RemoveBehaviour((Component)obj);
        }
    }
}
