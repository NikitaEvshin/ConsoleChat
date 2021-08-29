
namespace ConsoleApp15
{
    public class User
    {

        public string Name;
       

        public User(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
