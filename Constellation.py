from star import Star
from to_do_list import TodoList
class Constellation:
    # Starcords is a stars
    # tasks is a to do list object. where each task is set to an object
    def __init__(self):
        self.name = ""
        self.starList = []
       

    def __repr__(self):
        return f"Constellation Name: {self.name} with Stars: {self.starList}"
    
    # Add star to constellation, the coordinates are point objcets, so adding a point object to the list
    def add_star(self, star):
        # return task to create the star here
        self.starList.append(star)
        self.starList = sort_stars(self.starList)
        
    def remove_star(self, star):
        if(star not in self.starList):
            print(f"Star {star} not found in constellation.")
            return
        self.starList.remove(star)
        self.starList = sort_stars(self.starList)
    # return a new list of sorted stars        
   
    # return the star at an index
    def get_star(self, index):
        if index < 0 or index >= len(self.starList):
            raise IndexError("Star index out of range")
        return self.starList[index]
    
    def get_star_coordinates(self,index):
        return self.get_star(index).get_point()
    
    # return all the stars
    def get_all_stars(self):
        return self.starList
    
    # return all the tasks
    def get_tasks(self):
        task_list = []
        for star in self.starList:
            task_list.append(star.get_task())
        return task_list
    
    # return the name
    def get_constellation_name(self):
        return self.name
    
    def set_name(self, name):
        self.name = name
    
    def can_make_line(self, star1, star2):
        index_star1 = self.starList.index(star1)
        index_star2 = self.starList.index(star2)  
        if abs(index_star1 - index_star2) == 1:
            if star1.get_completion_status() and star2.get_completion_status():  
                return True
        
        return False

def sort_stars(starList):
    return sorted(starList, key=lambda star: (star.get_point().x, star.get_point().y))

    
    
# List of constellation objcets, used for later if we have time
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
    

