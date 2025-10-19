import sys
import os
# Import your custom classes
from Constellation import Constellation # Adjust this import as needed
from points import Point, PointList
from to_do_list import TodoList
from star import Star


def main():
    """
    Handles command-line arguments to get the JSON file path 
    and then loads and saves the constellation using that path.
    """
    # 1. Determine the path to the JSON file
    if len(sys.argv) > 1:
        # FIX 2: Uses the ABSOLUTE PATH passed from the C# code (sys.argv[1])
        json_file_path = sys.argv[1] 
    else:
        # Fallback for manual testing 
        json_file_path = "data/test.json" 
        os.makedirs("data", exist_ok=True) 

    print(f"Attempting to process file at: {json_file_path}")

    # 2. Load the constellation using the determined path
    Constellation1 = Constellation.load_from_json(json_file_path)
    
    # 3. Save the constellation back to the same path
    # FIX 2: Ensures the ABSOLUTE PATH is used for saving, resolving the "wrong directory" issue.
    print(f"Saving file at: {json_file_path}")
    Constellation1.save_to_json(json_file_path) 

if __name__ == "__main__":
    main()