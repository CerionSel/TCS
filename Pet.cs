

namespace TamagochiSel
{
    public class Pet
    {
        public int hunger;
        public int sleep;
        public int funny;
        public int health;
        public string name;
        public string title;

        public Pet(string name, string title)
        {
            this.name = name;
            this.title = title;
            hunger = 100;
            sleep = 100;
            funny = 100;
            health = 100;
        }
    }

}