public class PointList
{
    // The internal list of Point objects
    private List<Point> points;

    public PointList()
    {
        this.points = new List<Point>();
    }

    // Equivalent to add_point
    public void AddPoint(Point point)
    {
        this.points.Add(point);
    }

    // Equivalent to remove_point
    public void RemovePoint(Point point)
    {
        this.points.Remove(point);
    }

    // Equivalent to get_point
    public Point GetPoint(int index)
    {
        return this.points[index];
    }

    // Equivalent to get_range
    public List<Point> GetRange(int start, int end)
    {
        // List.GetRange() creates a shallow copy of the list range
        int count = end - start;
        return this.points.GetRange(start, count);
    }

    // Equivalent to get_points
    public List<Point> GetPoints()
    {
        return this.points;
    }
    
    // Equivalent to get_sorted_points (uses the static helper method)
    public List<Point> GetSortedPoints()
    {
        return PointSorter.SortPoints(this.points);
    }
}

public static class PointSorter
{
    // Equivalent to Python's def sort_points(points):
    public static List<Point> SortPoints(List<Point> points)
    {
        // 1. Create a copy of the list to sort (ensures the original list isn't modified)
        List<Point> sortedList = new List<Point>(points);

        // 2. Use List<T>.Sort() with a lambda expression for comparison:
        //    (a, b) => comparison result
        //    a.X.CompareTo(b.X) sorts by X first.
        //    If X values are equal (result == 0), it then sorts by Y.
        sortedList.Sort((a, b) => 
        {
            // Primary sort by X
            int xComparison = a.X.CompareTo(b.X);

            // Secondary sort by Y if X values are the same
            if (xComparison == 0)
            {
                return a.Y.CompareTo(b.Y);
            }

            return xComparison;
        });

        return sortedList;
    }
}