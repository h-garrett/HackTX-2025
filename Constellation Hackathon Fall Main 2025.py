from Constellation import Constellation, ConstellationList
from points import Point, PointList
from to_do_list import TodoList
from star import Star
import os


def main():
    
   
    star1 = Star(Point(4,0.22), "test 1")
    star2 = Star(Point(9,-1.4794129133224488), "data 2'")
    star3 = Star(Point( 1,0.32134079933166506), "data 3")
    star4 = Star(Point( 0,0), "data 4")
    Constellation1 = Constellation()
    Constellation1.set_name("My First Constellation")
    Constellation1.add_star(star1)
    Constellation1.add_star(star2)
    Constellation1.add_star(star3)
    Constellation1.add_star(star4)

    Constellation1.get_star(0).light_star()
    os.makedirs("data", exist_ok=True)

    Constellation2 = Constellation().load_from_json("data/test.json")
    print(Constellation2)
    Constellation1.save_to_json("data/test.json")
    


   

   
   
   
   
if __name__ == "__main__": 
   main()