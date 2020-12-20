using System.Linq;

namespace Day17
{
    public class SpaceRunner
    {
        public Space Step(Space current)
        {
            var newSpace = new Space();
            for (var z = current.Min(p => p.Z) - 1; z <= current.Max(p => p.Z) + 1; z++)
            {
                for (var y = current.Min(p => p.Y) - 1; y <= current.Max(p => p.Y) + 1; y++)
                {
                    for (var x = current.Min(p => p.X) - 1; x <= current.Max(p => p.X) + 1; x++)
                    {
                        var point = current[x, y, z];

                        // If a cube is active and exactly 2 or 3 of its neighbors are also active, the cube remains active. Otherwise, the cube becomes inactive.
                        // If a cube is inactive but exactly 3 of its neighbors are active, the cube becomes active. Otherwise, the cube remains inactive.
                        var adjacent = current.Surrounding(point);
                        var activeCount = adjacent.Count(x => x.Active);

                        if (point.Active)
                        {
                            if (activeCount == 2 || activeCount == 3)
                            {
                                newSpace.Enable(point.X, point.Y, point.Z);
                            }
                            else
                            {
                                newSpace.Disable(point.X, point.Y, point.Z);
                            }
                        }
                        else // Inactive
                        {
                            if (activeCount == 3)
                            {
                                newSpace.Enable(point.X, point.Y, point.Z);
                            }
                            else
                            {
                                newSpace.Disable(point.X, point.Y, point.Z);
                            }
                        }
                    }

                }
            }
            return newSpace;
        }
    }
}
