namespace Web.Entity
{
    public class Name 
    {
        private string text;

        private Name(string text)
        {
            this.text = text;
        }

        public static Name FromString(string text)
        {
            return new Name(text);
        }

        public override string ToString()
        {
            return text;
        }
    }
}