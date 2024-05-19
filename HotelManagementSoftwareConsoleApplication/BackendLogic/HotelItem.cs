

namespace HotelManagementSoftware;

public abstract class HotelItem : ISearchable
{
    public abstract bool MyContains(int value);
    public abstract bool MyContains(string value);

    public abstract override string ToString();
}

