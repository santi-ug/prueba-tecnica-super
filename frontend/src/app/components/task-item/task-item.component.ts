import { Component, Input, Output, EventEmitter } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Task } from "../../models/task.model";

@Component({
  selector: "app-task-item",
  standalone: true,
  imports: [CommonModule],
  templateUrl: "./task-item.component.html",
})
export class TaskItemComponent {
  @Input() task!: Task;
  @Output() remove = new EventEmitter<number>();
  @Output() toggle = new EventEmitter<number>();

  isRemoving = false;

  handleClick() {
    if (!this.task.id) return; // si no existe, chao

    this.isRemoving = true;
    setTimeout(() => {
      this.remove.emit(this.task.id);
    }, 300);
  }

  handleToggle(event: Event) {
    event.stopPropagation();
    if (this.task.id) {
      this.toggle.emit(this.task.id);
    }
  }
}
