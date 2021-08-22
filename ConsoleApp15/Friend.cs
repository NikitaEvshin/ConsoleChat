using System;

namespace ConsoleApp15
{
    public class Friend
    {

        public string Name;
        public string Message;
        public DateTime Time;

        public override string ToString()
        {
            return $"{Time} \t {Name}  {Message}";
        }
    }
}
