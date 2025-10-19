from Constellation import Constellation, ConstellationList
from points import Point, PointList
from to_do_list import TodoList

def main():
    test_point_list = PointList()
    test_point_list.add_point(Point(3, 4))
    test_point_list.add_point(Point(1, 2))
    test_point_list.add_point(Point(5, 4))

    test_point_list = test_point_list.get_sorted_points()
    print(test_point_list)    



    test_todo_list = TodoList()
    test_todo_list.add_task()
    
   

    test_constellation = Constellation(test_point_list, test_todo_list)
    print(test_constellation)
    test_constellation.add_star(Point(7, 8))
   

    print(test_constellation)

    # print(test_constellation.get_stars())
    # print(test_constellation.get_tasks())

   
   
   
   
if __name__ == "__main__": 
   main()