import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { TaskInputComponent } from "./components/task-input/task-input.component";
import { TaskListComponent } from "./components/task-list/task-list.component";
import { TaskService } from "./services/task.service";
import { Task } from "./models/task.model";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    TaskInputComponent,
    TaskListComponent,
  ],
  providers: [TaskService],
  templateUrl: "./app.html",
})
export class App implements OnInit {
  tasks: Task[] = [];

  constructor(
    private taskService: TaskService,
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        this.tasks = tasks;
        this.cdr.detectChanges(); // Force change detection
      },
      error: (err) => {
        console.error("Error loading tasks:", err);
      },
    });
  }

  addTask(text: string) {
    this.taskService.createTask({ title: text, completed: false }).subscribe({
      next: () => {
        this.loadTasks();
      },
      error: (err) => {
        console.error("Error adding task:", err);
      },
    });
  }

  removeTask(id: number) {
    this.taskService.deleteTask(id).subscribe({
      next: () => {
        this.loadTasks();
      },
      error: (err) => {
        console.error("Error removing task:", err);
      },
    });
  }

  toggleTask(id: number) {
    const task = this.tasks.find((t) => t.id === id);
    if (!task) return;

    this.taskService
      .updateTask(id, {
        ...task,
        completed: !task.completed,
      })
      .subscribe({
        next: () => {
          this.loadTasks();
        },
        error: (err) => {
          console.error("Error toggling task:", err);
        },
      });
  }
}
