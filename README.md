# TaskManager
Console program for managing tasks.
- **/add** *task-info* - creates a new task
- **/all** - displays all tasks
- **/delete id** - deletes a task by ID
- **/save** *file-name.txt* - saves all current tasks to the specified file
- **/load** *file-name.txt* - loads tasks from a file
- **/complete** *id* - indicates that the task is completed
- **/completed** - displays all completed tasks
- **/set-deadline** *id* *dd.mm.yyyy* - the ability to specify the due date (deadline)
- **/today** - displays only those tasks that need to be done today
- Task grouping - the ability to create task groups
     - **/create-group** *group-name* - creates a group for tasks
     - **/delete-group** *group-name* - deletes a group with the given name
     - **/add-to-group** *id* *group-name* - adds a task with the specified id to the group with the specified name
     - **/delete-from-group** *id* *group-name* - deletes the task from the group
- Subtasks
     - Command **/add-subtask** *id* *subtask-info* - adds a subtask to the selected task
     - **/complete** *id* - indicates that the subtask is completed

Result
```
[x] {task-id} task-info
[ ] {2} Go shopping
   - [ ] {3} buy milk
   - [x] {4} buy chips
[ ] (12/22/2022) {5} Do lab work
```
