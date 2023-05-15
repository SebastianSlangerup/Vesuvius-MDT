namespace Vesuvius_MDT.Models;
public class Interval
{
    public Interval(DateTime start, DateTime end, IEnumerable<Reservation> reservations)
    {
        var reservations_list = reservations.ToList();
        foreach (var reservation in reservations_list)
        {
            if (reservation.ReservationId == 0)
            {
                this.Start = start;
                this.end = end;
                this.availabe = true;

            }
            else
            {
                start = reservation.ResevationStart;
                end = reservation.ResevationEnd;
                this.availabe = false;
            }
        }
        
      
    }
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime end { get; set; }
    public int ReservationId { get; set; }
    public bool availabe { get; set; }
}