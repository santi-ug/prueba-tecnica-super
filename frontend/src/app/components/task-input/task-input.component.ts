import { Component, Output, EventEmitter } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

@Component({
  selector: "app-task-input",
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: "./task-input.component.html",
})
export class TaskInputComponent {
  @Output() add = new EventEmitter<string>();
  value = "";

  handleSubmit(event: Event) {
    event.preventDefault();
    if (this.value.trim()) {
      this.add.emit(this.value.trim()); // para eliminar espacios al final
      this.value = "";
    }
  }
}
