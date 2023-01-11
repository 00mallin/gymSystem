namespace Logic;

public class MembershipType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Days { get; set; }
    public float PricePerMonth { get; set; }

    public MembershipType() { }
}