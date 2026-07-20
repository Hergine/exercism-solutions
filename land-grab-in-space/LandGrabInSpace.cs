public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    // Change these to public properties so we can read them later
    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
    }
}


public class ClaimsHandler
{
    private HashSet<Plot> _stakedClaims = new HashSet<Plot>();
    private Plot _lastClaim;
    public void StakeClaim(Plot plot)
    {
        _stakedClaims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _stakedClaims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return _lastClaim.Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
       Plot longestPlot = new Plot();
        int maxSideLength = 0;

        foreach (var plot in _stakedClaims)
        {
            // Calculate Width: Max X - Min X
            var xValues = new[] { plot.Coord1.X, plot.Coord2.X, plot.Coord3.X, plot.Coord4.X };
            int width = xValues.Max() - xValues.Min();

            // Calculate Height: Max Y - Min Y
            var yValues = new[] { plot.Coord1.Y, plot.Coord2.Y, plot.Coord3.Y, plot.Coord4.Y };
            int height = yValues.Max() - yValues.Min();

            // The longest side of this specific plot
            int currentLongestSide = Math.Max(width, height);

            // Compare with the record holder
            if (currentLongestSide > maxSideLength)
            {
                maxSideLength = currentLongestSide;
                longestPlot = plot;
            }
        }

        return longestPlot;
    }
}
