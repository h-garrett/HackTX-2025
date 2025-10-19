import sys  # <--- New import for command-line arguments
import os
from Constellation import Constellation, ConstellationList
from points import Point, PointList
from to_do_list import TodoList
from star import Star

def main():
    # 1. Determine the path to the JSON file
    if len(sys.argv) > 1:
        # Use the absolute path passed from the C# code (sys.argv[1])
        json_file_path = sys.argv[1]
    else:
        # Fallback for manual testing (using a relative path)
        json_file_path = "data/test.json" 
        os.makedirs("data", exist_ok=True) # Only create 'data' folder if using fallback

    print(f"Attempting to load/save file at: {json_file_path}")

    # 2. Use the determined path to load and save
    
    # NOTE: Calling Constellation() then .load_from_json() is unusual. 
    # load_from_json is a @classmethod and should be called on the class itself.
    # Assuming your Constellation class is structured for this:
    # (If not, use Constellation = Constellation.load_from_json(path))
    
    Constellation1 = Constellation().load_from_json(json_file_path)
    
    # 3. Save to the same determined path
    Constellation1.save_to_json(json_file_path)

# This block ensures the main() function runs when the script is executed
if __name__ == "__main__":
    main()
   
