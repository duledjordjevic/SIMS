namespace Biblioteka.Model
{
    public class Publisher
    {
        public string Name { get; set; }
        public string HeadOffice { get; set; }
        public Publisher() { }
        public Publisher(string name, string headOffice)        {
            Name = name;
            HeadOffice = headOffice;
        }

    }
}