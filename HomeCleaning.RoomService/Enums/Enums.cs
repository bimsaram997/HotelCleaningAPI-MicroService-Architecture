namespace HomeCleaning.RoomService.Enums
{
    public enum RoomStatus
    {
        Available = 0,
        Occupied = 1,
        Cleaning = 2,
        OutOfService = 3
    }

    public enum RoomType
    {
        Standard = 0,
        Superior = 1
    }

    public enum BedType
    {
        Default = 0,       // Implicit 2 beds
        SofaBed = 1,  // Sofas, fixed extra beds
        RollingBed = 2     // Customer-requested
    }

}
