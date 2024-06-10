namespace PlayGroundLib
{
    public class PlayGround
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaxChildren { get; set; }
        public int MinAge { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, MaxChildren: {MaxChildren}, MiniAge: {MinAge}";
        }



    }
}
