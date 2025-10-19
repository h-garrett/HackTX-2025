
class TodoList:
    def __init__(self):
        self.to_do_list = []

    def run(self):
        while True:
            #show menu for user to choose from
            print("To-Do List Menu")
            print("1. View all tasks")
            print("2. Add a task")
            print("3. Complete a task")
            print("4. Delete a task")
            print("5. Clear all tasks")

            #ask user what option they want
            choice = input("Enter your choice (1-5): ")

            #based on what the user chooses, it will run the respective functions
            if choice == "1":
                self.view_tasks()

            elif choice == "2":
                self.add_task()

            elif choice == '3':
                self.complete_task()

            elif choice == "4":
                self.remove_task()
            
            elif choice == '5':
                self.to_do_list.clear()
                print("All tasks cleared")

            else:
                print("Invalid choice. Please enter 1-5.")

    #this function will add a task to to-do list
    def add_task(self):
        #ask the user to input a task
        task = {
            'number': len(self.to_do_list) + 1,
            'name': input("Enter task: "),
            'completed': False,
        }
        #adding the task if it does already exist
        if task not in self.to_do_list:
            self.to_do_list.append(task)
            print(f"Task sucessfully added")
        else: 
            print(f"That task already exists.")

    #this function will allow the user to view the full to-do list
    def view_tasks(self):
        if not self.to_do_list:
            print("There are no tasks yet. Add one to get started.")
            return
        
        #mark task appropriately based on status (✓ = completed, ○ = not completed)
        for task in self.to_do_list:
            status = "✓" if task['completed'] else "○"

            #if task is completed, it will have a strikethrough for the task
            task_name = task['name']
            if task['completed']:
                task_name = f"\033[9m{task_name}\033[0m"  # Strikethrough

            print(f"{status} [{task['number']}] {task_name}")

    #this function will mark a task as complete
    def complete_task(self):
        self.view_tasks()
        task_number = int(input(f"Enter task number completed: ")) 
        for task in self.to_do_list:
            if task['number'] == task_number:
                task['completed'] = True
                print(f"✓ Task {task_number} marked as complete!")
                return
            
        print((f"Task {task_number} not found."))

    #this function will remove a task from the to-do list
    def remove_task(self):
        self.view_tasks()
        try:
            task_number = int(input("Enter task number to remove: "))
            for i, task in enumerate(self.to_do_list):
                if task['number'] == task_number:
                    removed = self.to_do_list.pop(i)
                    print(f"Task Sucessfully Removed")
                    return
            print(f"Task {task_number} not found.") 
        except ValueError:
            print(f"Please enter a valid task number.")   
    
#runs the program
if __name__ == "__main__":
    todo_list = TodoList()
    todo_list.run()