namespace MusicBox.Exceptions
{
    internal class WrongCommandException : Exception
    {
        public WrongCommandException() : base("You entered Wrong input")
        {

        }
    }
}
