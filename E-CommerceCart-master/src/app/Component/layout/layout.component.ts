import { Component } from '@angular/core';
import { HomeComponent } from "../home/home.component";
import { BucketComponent } from "../bucket/bucket.component";
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [HomeComponent,RouterOutlet,RouterLink,BucketComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
  