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
        # Uses the ABSOLUTE PATH passed from the C# code (sys.argv[1])
        json_file_path = sys.argv[1] 
    else:
        # Fallback for manual testing 
        json_file_path = "data/starData.json" 
        os.makedirs("data", exist_ok=True) 

    print(f"Attempting to process file at: {json_file_path}")

    # 2. Load the constellation using the determined path
    # CRITICAL: load_from_json may return None if the file is corrupted.
    Constellation1 = Constellation.load_from_json(json_file_path)
    
    # 🌟 FIX: Only proceed to save if the load was successful (Constellation1 is not None) 🌟
    if Constellation1 is not None:
        # 3. Save the constellation back to the same path
        # FIX 1: UNCOMMENTED the save line
        Constellation1.save_to_json(json_file_path)
    else:
        print("🛑 Save aborted because JSON file failed to load (corrupted).")


if __name__ == "__main__":
    main()