import sys
import os
import json
# Assuming 'Constellation' and other classes are correctly imported
from Constellation import Constellation # Adjust this if Constellation is in a different file
from points import Point
from star import Star


def main():
    """
    Handles command-line arguments to get the JSON file path 
    and then loads and saves the constellation.
    """
    # 1. Determine the path to the JSON file using the argument from Unity (sys.argv[1])
    if len(sys.argv) > 1:
        json_file_path = sys.argv[1]
    else:
        # Fallback for manual testing 
        json_file_path = "data/test.json" 
        os.makedirs("data", exist_ok=True) # Only create 'data' folder if using fallback

    print(f"Attempting to process file at: {json_file_path}")

    # 2. Load the constellation
    # We use the classmethod Constellation.load_from_json() to create the object
    Constellation1 = Constellation.load_from_json(json_file_path)
    
    # 3. Save the constellation back to the same path (which now includes the sorting fix)
    Constellation1.save_to_json(json_file_path)

if __name__ == "__main__":
    main()