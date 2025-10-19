from points import Point, PointList
from to_do_list import TodoList

class Constellation:
    def __init__(self, PointList, TodoList):
        self.name = ""
        self.starCords = PointList
        self.tasks = TodoList

    def __repr__(self):
        return f"Constellation Name: {self.name} with Stars: {self.starCords} and Tasks: {self.tasks.to_do_list}"
    
    # Add star coordinates to constellation, the coordinates are point objcets, so adding a point object to the list
    def add_star(self, point):
        self.starCords.append(point)
        self.tasks.add_task()

    def get_stars(self):
        return self.starCords
    
    def get_tasks(self):
        return self.tasks.to_do_list
    
    def get_constellation_name(self):
        return self.name
    
    def set_name(self, name):
        self.name = name

    
    

class ConstellationList:
    def __init__(self):
        self.constellations = []

    def add_constellation(self, constellation):
        self.constellations.append(constellation)

    def remove_constellation(self, constellation):
        self.constellations.remove(constellation)

    def get_all_constellations(self):
        return self.constellations
    
    def get_constellation(self, index):
        return self.constellations[index]
    
    def get_constellation_range(self, start, end):
        return self.constellations[start:end]
    

