namespace Day05
{
    public class BoardingPass
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatID => Row * 8 + Column;
    }
}
