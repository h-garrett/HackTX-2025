import json
# Import your custom classes
from star import Star
from points import Point 
from to_do_list import TodoList

# --- Helper Function (CONFIRMED) ---
def sort_stars(starList):
    """Sorts the list of Star objects primarily by X-coordinate, then by Y."""
    # We rely on the get_point(), get_x_coordinate(), and get_y_coordinate() methods
    return sorted(starList, 
        key=lambda star: (star.get_point().get_x_coordinate(), star.get_point().get_y_coordinate())
    )

# ----------------------------------------------------------------------
# --- Constellation Class ---
# ----------------------------------------------------------------------

class Constellation:
    
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
    
    def to_dict(self):
        """Convert the constellation to a dict matching starData.json format."""
        stars_data = []
        # CRITICAL: The list being iterated over (self.starList) MUST BE sorted for the output to be sorted.
        for star in self.starList: 
            point = star.get_point()
            star_data = {
                "x": point.get_x_coordinate(),
                "y": point.get_y_coordinate(),
                "task": star.get_task(),
                "complete": star.get_completion_status(),
                "connected": False 
            }
            stars_data.append(star_data)
        return {"stars": stars_data}
    
    def save_to_json(self, filename): 
        """Save the constellation to a JSON file."""
        data = self.to_dict()
        with open(filename, "w") as f:
            json.dump(data, f, indent=4)
        print(f"✅ Constellation saved to {filename}")
    
    @classmethod
    def load_from_json(cls, filename): 
        """Load constellation data from a JSON file into a Constellation object."""
        constellation = cls()
        try:
            with open(filename, "r") as f:
                data = json.load(f)
                
            for star_data in data.get("stars", []):
                point = Point(star_data["x"], star_data["y"])
                star = Star(point, star_data["task"])
                if star_data.get("complete"):
                    star.light_star()
                
                constellation.starList.append(star) 
            
            # FIX CONFIRMATION: This ensures the list is sorted after loading 
            # and before the subsequent save operation.
            constellation.starList = sort_stars(constellation.starList) 
            
            print(f"✅ Loaded constellation with {len(constellation.starList)} stars from {filename}")
            
        except FileNotFoundError:
            print(f"⚠️ File not found at path: {filename}")
        except json.JSONDecodeError:
            print(f"⚠️ Error decoding {filename}. Check JSON formatting.")
        return constellation
    
   

    
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
    

