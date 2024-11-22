import { Component } from '@angular/core';
import { HomeComponent } from "../home/home.component";
import { BucketComponent } from "../bucket/bucket.component";

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [HomeComponent, BucketComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {

}
