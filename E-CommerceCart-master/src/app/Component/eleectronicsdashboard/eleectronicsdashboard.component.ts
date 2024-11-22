import { Component } from '@angular/core';
import { EleectronicsProductsComponent } from "../eleectronics-products/eleectronics-products.component";
import { EcartComponent } from "../ecart/ecart.component";

@Component({
  selector: 'app-eleectronicsdashboard',
  standalone: true,
  imports: [EleectronicsProductsComponent, EcartComponent],
  templateUrl: './eleectronicsdashboard.component.html',
  styleUrl: './eleectronicsdashboard.component.css'
})
export class EleectronicsdashboardComponent {

}
