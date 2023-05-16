namespace Vesuvius_MDT.Dtos;

public class ReservationDto
{
    public int TableId { get; set; }

    public DateTime ReservationDateTime { get; set; }

    public DateTime ResevationStart { get; set; }

    public DateTime ResevationEnd { get; set; }

    public int CustomerRefId { get; set; }

    public string Extra { get; set; }
}