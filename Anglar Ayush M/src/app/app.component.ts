import { Component, afterNextRender } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContainerComponent } from "./components/container/container.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ContainerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'POCs';

  constructor() {
    afterNextRender({
      read: (didWrite) => {
        console.log("read called");
      },
      // Use the `Write` phase to write to a geometric property.
      write: () => {
        console.log("write called");

      }
      // Use the `Read` phase to read geometric properties after all writes have occurred.
    
    });
  }



}
