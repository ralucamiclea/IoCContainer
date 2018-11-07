namespace MovieApp
{
    public interface IMovie
    {
        string Name { get; set; }
        string Director { get; set; }
        int Length { get; set; }
    }
}