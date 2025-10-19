from Constellation import Constellation, ConstellationList
from points import Point, PointList
from to_do_list import TodoList
from star import Star


def main():
    
   
    star1 = Star(Point(-4.144836902618408,0.8801946640014648), "test 1")
    star2 = Star(Point(-1.189117431640625,-1.4794129133224488), "data 2'")
    star3 = Star(Point( 2.1888468265533449,0.32134079933166506), "data 3")
    Constellation1 = Constellation()
    Constellation1.set_name("My First Constellation")
    Constellation1.add_star(star1)
    Constellation1.add_star(star2)
    Constellation1.add_star(star3)
    
    Constellation1.get_star(0).light_star()
    Constellation1.get_star(1).light_star()
    print(Constellation1.can_make_line(star1,star3)) # False
    

   

   
   
   
   
if __name__ == "__main__": 
   main()