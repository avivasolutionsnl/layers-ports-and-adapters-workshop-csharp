namespace Web.Entity
{
    public class Description 
    {
        private string text;

        private Description(string text)
        {
            this.text = text;
        }

        public static Description FromString(string text)
        {
            return new Description(text);
        }

        public override string ToString()
        {
            return text;
        }
    }
}