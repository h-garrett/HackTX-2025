
def main():
    to_do_list = []

    while True:
        print("To-Do List Menu")
        print("1. View all tasks")
        print("2. Add a task")
        print("3. Complete a task")
        print("4. Delete a task")
        print("5. Exit")

        choice = input("Enter your choice (1-5): ")

        if choice == "1":
            view_tasks(to_do_list)

        elif choice == "2":
            add_task(to_do_list)

        elif choice == '3':
            complete_task(to_do_list)

        elif choice == "4":
            remove_task(to_do_list)
        
        elif choice == '5':
            to_do_list.clear()
            print("All tasks cleared")

        else:
            print("Invalid choice. Please enter 1-5.")


def add_task(to_do_list):
    #asking the user to input a task
    task = {
        'number': len(to_do_list) + 1,
        'name': input("Enter task: "),
        'completed': False,
    }
    #adding task if it does already exist
    if task not in to_do_list:
        to_do_list.append(task)
        print(f"Task sucessfully added")
    else: 
        print(f"That task already exists.")


def view_tasks(to_do_list):
    if not to_do_list:
        print("There are no tasks yet. Add one to get started.")
        return
    
    for task in to_do_list:
        status = "✓" if task['completed'] else "○"

        task_name = task['name']
        if task['completed']:
            task_name = f"\033[9m{task_name}\033[0m"  # Strikethrough

        print(f"{status} [{task['number']}] {task_name}")


def complete_task(to_do_list):
    view_tasks(to_do_list)
    task_number = int(input(f"Enter task number completed: ")) 
    for task in to_do_list:
        if task['number'] == task_number:
            task['completed'] = True
            print(f"✓ Task {task_number} marked as complete!")
            return
        
    print((f"Task {task_number} not found."))


def remove_task(to_do_list):
    view_tasks(to_do_list)
    try:
        task_number = int(input("Enter task number to remove: "))
        for i, task in enumerate(to_do_list):
            if task['number'] == task_number:
                removed = to_do_list.pop(i)
                print(f"Task Sucessfully Removed")
                return
        print(f"Task {task_number} not found.") 
    except ValueError:
        print(f"Please enter a valid task number.")   
    

if __name__ == "__main__":
    main()