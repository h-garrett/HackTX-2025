from Constellation import Constellation, ConstellationList
from points import Point, PointList
from to_do_list import TodoList
from star import Star
import os


def main():
  
    os.makedirs("data", exist_ok=True)

    Constellation1 = Constellation().load_from_json("data/test.json")
    Constellation1.save_to_json("data/test.json")
    


   

   
   
   
   
if __name__ == "__main__": 
   main()