
class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __repr__(self):
        return f"Coordinates ({self.x}, {self.y})"


def sort_points(points):
    return sorted(points, key=lambda p: (p.x, p.y))


class PointList:
    def __init__(self):
        self.points = []

    def add_point(self, point):
        self.points.append(point)
    
    def remove_point(self, point):
        self.points.remove(point)

    def get_sorted_points(self):
        return sort_points(self.points)
    
    def get_point(self, index):
        return self.points[index]
    
    def get_range(self, start, end):
        return self.points[start:end]
    
    def get_points(self):
        return self.points



