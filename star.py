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

    # When a task is compleded the star goes from dim to light
    # Called whenever the task is marked completed in the to do list
    def light_star (self):
        self.completed = True
        
    # Show if a star is completed or not
    def get_completion_status(self):
        return self.completed
    
    