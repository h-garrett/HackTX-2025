from points import Point, PointList
from to_do_list import TodoList

# Represnet a star
# The point is its x and y coordinates
# The task is the task associated with the star from the to do list
# Completed is whether the task is completed or not
class Star:
    def __init__(self, point, task):
        self.coordinates = point
        self.task = task
        self.completed = False

        def __repr__(self):
            return f"Coordinates of Star ({self.get_star_x_coordinate}, {self.get_star_y_coordinate}) with Task: {self.task} Completed: {self.completed}" 

    # When a task is compleded the star goes from dim to light
    # Called whenever the task is marked completed in the to do list
    def light_star (self):
        self.completed = True
        
    # Show if a star is completed or not
    def get_completion_status(self):
        return self.completed
    
    def get_point(self):
        return self.coordinates
    
    def get_task(self):
        return self.task
    
    def get_star_x_coordinate(self):
        return self.coordinates.get_x_coordinate()
    
    def get_star_y_coordinate(self):
        return self.coordinates.get_y_coordinate()
    
    