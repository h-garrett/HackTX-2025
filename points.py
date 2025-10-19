
class Point:
    # Represents a point in 2D space
    # x is the x coordinate
    # y is the y coordinate
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __repr__(self):
        return f"Coordinates ({self.x}, {self.y})"

# sorts the points in a list based on x and y values
# does x first, then y
def sort_points(points):
    return sorted(points, key=lambda p: (p.x, p.y))


class PointList:
    # Represents a list of Point objects
    def __init__(self):
        self.points = []

    def add_point(self, point):
        self.points.append(point)
    
    def remove_point(self, point):
        self.points.remove(point)
    # returns a new PointList with sorted points
    def get_sorted_points(self):
        return sort_points(self.points)
    # get the point at an index
    def get_point(self, index):
        return self.points[index]
    # get a range of points from start to end index
    def get_range(self, start, end):
        return self.points[start:end]
    # get all the points
    def get_points(self):
        return self.points



